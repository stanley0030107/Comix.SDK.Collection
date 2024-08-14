﻿using Comix.Core.Helpers;
using NewLife.Caching;
using RedisHelper = Comix.Core.Helpers.RedisHelper;

namespace Comix.Core.EventBus;
/// <summary>
/// Redis自定义事件源存储器
/// </summary>
public class RedisEventSourceStorer : IEventSourceStorer
{
    private readonly Channel<IEventSource> _channel; // 内存通道事件源存储器

    private readonly RedisHelper _redis;

    // private readonly string _topic = "eventbus";

    public RedisEventSourceStorer(RedisHelper redis, int capacity = 10000)
    {
        _redis = redis;

        // 配置通道（超出默认容量后进入等待）
        var boundedChannelOptions = new BoundedChannelOptions(capacity)
        {
            FullMode = BoundedChannelFullMode.Wait
        };
        // 创建有限容量通道
        _channel = Channel.CreateBounded<IEventSource>(boundedChannelOptions);
        //RedisHelper.Subscribe((_topic, msg =>
        //{
        //    var eventSource = JSON.Deserialize<ChannelEventSource>(msg.Body);
        //    // 写入内存管道存储器
        //    _channel!.Writer.TryWrite(eventSource);
        //}
        //));
    }

    /// <summary>
    /// 往 Redis 中写入一条
    /// </summary>
    /// <param name="eventSource"></param>
    /// <param name="cancellationToken"></param>
    public async ValueTask WriteAsync(IEventSource eventSource, CancellationToken cancellationToken)
    {
        if (eventSource is ChannelEventSource es)
        {
            //await RedisHelper.PublishAsync(_topic, JSON.Serialize(es));
        }
        else
        {
            await _channel.Writer.WriteAsync(eventSource, cancellationToken);
        }
    }

    /// <summary>
    /// 从 Redis 中读取一条
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IEventSource> ReadAsync(CancellationToken cancellationToken)
    {
        return await _channel.Reader.ReadAsync(cancellationToken);
    }
}
