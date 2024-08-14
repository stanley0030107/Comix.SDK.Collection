using System.Collections.Concurrent;
using Comix.Core.Helpers;
using Furion.LinqBuilder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Comix.Core.DbMonitor;

public abstract class BatchDbMonitor<T> : IHostedService where T : struct
{
    private bool _polling;
    private readonly ILogger<BatchDbMonitor<T>> _logger;
    private Timer _timer;

    /// <summary>
    /// redis队列名称
    /// </summary>
    protected readonly string _queueName;

    /// <summary>
    /// 内存队列
    /// </summary>
    protected ConcurrentQueue<T> _needDealSyncIds;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志</param>
    /// <param name="queueName">redis队列名称</param>
    public BatchDbMonitor(ILogger<BatchDbMonitor<T>> logger,
        string queueName, ConcurrentQueue<T> needDealSyncIds)
    {
        _logger = logger;
        _queueName = queueName;
        _needDealSyncIds = needDealSyncIds;
        _polling = false;
    }

    /// <summary>
    /// 推送数据到es
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    protected abstract Task PushToEs(T[] data);

    /// <summary>
    /// 添加数据到队列
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    protected abstract Task Enqueue(T[] items);

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await LoadHisData();

        _logger.LogError("{BatchDwSapDeliveryHeadDbMonitorName} 批量数据推送es启动，恢复数据{Count}",
            _queueName, _needDealSyncIds.Count);

        _timer = new Timer(Callback, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(4));
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
                    //循环取日志记录，直到队列为空，或者要超过1000条
                    while (orderCodes.Count <= 50 && _needDealSyncIds.TryDequeue(out var orderCode))
                    {
                        orderCodes.Add(orderCode);
                    }

                    var needCount = _needDealSyncIds.Count;

                    //如果存在要写入的日志，插入es
                    if (orderCodes.Count > 0)
                    {
                        _logger.LogInformation(
                            "{BatchDwSapDeliveryHeadDbMonitorName} 批量数据推送es，共取出数据{OrderCodesCount}，剩余数据{Count}",
                            _queueName, orderCodes.Count, needCount);

                        await DoWork(orderCodes.ToArray(), 0);
                    }

                    if (needCount == 0)
                    {
                        await Task.Delay(500, cancellationToken);
                    }
                } while (!_needDealSyncIds.IsEmpty);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{_queueName} 批量数据推送es 推送异常");
            }
            finally
            {
                _polling = false;
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        if (!_needDealSyncIds.IsEmpty)
        {
            _logger.LogError("{BatchDwSapDeliveryHeadDbMonitorName} 批量数据推送es退出，剩余数据{Count}",
                _queueName, _needDealSyncIds.Count);
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

        if (typeof(T) == typeof(Guid) || typeof(T) == typeof(string))
        {
            foreach (var item in items)
            {
                convertedItem = (T)TypeDescriptor.GetConverter(typeof(T))
                    .ConvertFromInvariantString(item.Value.ToString());
                _needDealSyncIds.Enqueue(convertedItem);
            }
        }
        else
        {
            foreach (var item in items)
            {
                convertedItem = (T)Convert.ChangeType(item.Value, typeof(T));
                _needDealSyncIds.Enqueue(convertedItem);
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
        var logger = Log.CreateLogger<BatchDbMonitor<T>>();

        try
        {
            logger.LogInformation("{BatchDwSapDeliveryHeadDbMonitorName} 批量数据推送es 开始更新，{OrderCodeStr}",
                _queueName, syncIdStr);

            await PushToEs(data);

            logger.LogInformation("{BatchDwSapDeliveryHeadDbMonitorName} 批量数据推送es 更新完成，{OrderCodeStr}",
                _queueName, syncIdStr);

            var redisHelper = App.GetService<RedisHelper>();
            await redisHelper.HRemoveAsync(_queueName, syncIds);
        }
        catch (Exception ex)
        {
            if (retry < 4)
            {
                await Task.Delay(1000 * ++retry);
                await DoWork(data, retry);
            }
            else
            {
                //重试次数大于3，发消息到企微
                logger.LogError(ex, "{BatchDwSapDeliveryHeadDbMonitorName} 批量数据推送es 第{Retry}次执行 推送异常 {OrderCodeStr}",
                    _queueName, retry, syncIdStr);
                await Enqueue(data);
                return;
            }

            logger.LogWarning(ex, "{BatchDwSapDeliveryHeadDbMonitorName} 批量数据推送es 第{Retry}次执行 推送异常 {OrderCodeStr}",
                _queueName, retry, syncIdStr);
        }
    }
}