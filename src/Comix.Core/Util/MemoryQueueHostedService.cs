using System.Collections.Concurrent;
using Comix.Core.Helpers;
using Furion.LinqBuilder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Comix.Core.Util;

/// <summary>
/// 内存队列后台服务
///
/// 功能：
/// 把数据添加到内存队列中，异步排队批量执行，每次执行50条处理，可以降低数据处理压力
///
/// 异常处理：
/// 如果执行业务异常，立马自动重拾3次，每次等待重拾次数*1秒，比如第一次重拾失败，等待1秒后执行，第2次失败等待2秒后执行
/// 如果重拾次数超过3次，发送企微消息，消息重新入列
///
/// 自动恢复
/// 程序中断，或者异常崩溃后，通过redis提供自动恢复队列的能力
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class MemoryQueueHostedService<T> : IHostedService
{
    private bool _polling;
    private readonly ILogger<MemoryQueueHostedService<T>> _logger;
    private Timer _timer;

    /// <summary>
    /// redis队列名称
    /// </summary>
    protected readonly string _queueName;

    /// <summary>
    /// 内存队列
    /// </summary>
    protected ConcurrentQueue<T> _needDealDatas;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志</param>
    /// <param name="queueName">redis队列名称</param>
    public MemoryQueueHostedService(ILogger<MemoryQueueHostedService<T>> logger,
        string queueName, ConcurrentQueue<T> needDealDatas)
    {
        _logger = logger;
        _queueName = queueName;
        _needDealDatas = needDealDatas;
        _polling = false;
    }

    /// <summary>
    /// 执行
    /// </summary>
    /// <param name="data"></param>
    /// <returns>移除redis缓存的key</returns>
    protected abstract Task<string[]> Do(T[] data);

    /// <summary>
    /// 添加数据到队列
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    protected abstract Task Enqueue(T[] items);

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await LoadHisData();

        _logger.LogError("{BatchDwSapDeliveryHeadDbMonitorName} 启动，恢复数据{Count}",
            _queueName, _needDealDatas.Count);

        _timer = new Timer(Callback, null, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(4));
        return;

        async void Callback(object? x)
        {
            if (_polling)
            {
                return;
            }

            try
            {
                _polling = true;

                do
                {
                    var orderCodes = new List<T>();
                    //循环取数据，直到队列为空，或者要超过1000条
                    while (orderCodes.Count <= 50 && _needDealDatas.TryDequeue(out var orderCode))
                    {
                        orderCodes.Add(orderCode);
                    }

                    var needCount = _needDealDatas.Count;

                    //如果存在数据
                    if (orderCodes.Count > 0)
                    {
                        _logger.LogInformation(
                            "{BatchDwSapDeliveryHeadDbMonitorName} 共取出数据{OrderCodesCount}，剩余数据{Count}",
                            _queueName, orderCodes.Count, needCount);

                        await DoWork(orderCodes.ToArray(), 0);
                    }

                    if (needCount == 0)
                    {
                        await Task.Delay(1000, cancellationToken);
                    }
                } while (!_needDealDatas.IsEmpty);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{_queueName} 推送异常");
            }
            finally
            {
                _polling = false;
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        if (!_needDealDatas.IsEmpty)
        {
            _logger.LogError("{BatchDwSapDeliveryHeadDbMonitorName} 退出，剩余数据{Count}",
                _queueName, _needDealDatas.Count);
        }

        return Task.CompletedTask;
    }

    /// <summary>
    /// 加载历史数据
    ///
    /// 从redis hash加载数据
    /// </summary>
    private async Task LoadHisData()
    {
        var redis = App.GetService<RedisHelper>();
        var items = await redis.HGetAllAsync<T>(_queueName);
        if (items.IsNullOrEmpty())
        {
            return;
        }

        T convertedItem;

        var type = typeof(T);
        if (type == typeof(Guid) || type == typeof(string))
        {
            foreach (var item in items)
            {
                convertedItem = (T)TypeDescriptor.GetConverter(typeof(T))
                    .ConvertFromInvariantString(item.Value.ToString());
                _needDealDatas.Enqueue(convertedItem);
            }
        }
        if (type.IsPrimitive || type == typeof(string))
        {
            foreach (var item in items)
            {
                convertedItem = (T)Convert.ChangeType(item.Value, typeof(T));
                _needDealDatas.Enqueue(convertedItem);
            }
        }
        else
        {
            foreach (var item in items)
            {
                var data = JSON.Deserialize<T>(item.Value);
                _needDealDatas.Enqueue(data);
            }
        }
    }


    /// <summary>
    /// 执行业务
    /// </summary>
    /// <param name="data"></param>
    /// <param name="retry"></param>
    public async Task DoWork(T[] data, int retry = 0)
    {
        var syncIds = data.Select(o => o.ToString()).ToArray();
        var syncIdStr = string.Join(",", syncIds);
        var logger = Log.CreateLogger<MemoryQueueHostedService<T>>();

        try
        {
            logger.LogInformation("{BatchDwSapDeliveryHeadDbMonitorName} 开始更新，{OrderCodeStr}",
                _queueName, syncIdStr);

            var ids = await Do(data);

            logger.LogInformation("{BatchDwSapDeliveryHeadDbMonitorName} 更新完成，{OrderCodeStr}",
                _queueName, syncIdStr);

            var redisHelper = App.GetService<RedisHelper>();
            var b = await redisHelper.HRemoveAsync(_queueName, ids);
        }
        catch (Exception ex)
        {
            if (retry < 4)
            {
                logger.LogWarning(ex, "{BatchDwSapDeliveryHeadDbMonitorName} 第{Retry}次执行 推送异常 {OrderCodeStr}",
                    _queueName, retry, syncIdStr);
                await Task.Delay(1000 * ++retry);
                await DoWork(data, retry);
            }
            else
            {
                //重试次数大于3，发消息到企微
                logger.LogError(ex, "{BatchDwSapDeliveryHeadDbMonitorName} 第{Retry}次执行 推送异常 {OrderCodeStr}",
                    _queueName, retry, syncIdStr);
                await Enqueue(data);
            }
        }
    }
}