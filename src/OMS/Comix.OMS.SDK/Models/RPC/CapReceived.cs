namespace Comix.OMS.SDK.Models.RPC;

    public class CapReceived
    {
        //
        // 摘要:
        //     主键
        // //[Display(Name = "主键")]
        public virtual string OID { get; set; }

        //
        // 摘要:
        //     版本
        //[Display(Name = "版本")]
        public virtual string VersionNo { get; set; }

        //
        // 摘要:
        //     队列名称
        //[Display(Name = "队列名称")]
        public virtual string QueueName { get; set; }

        //
        // 摘要:
        //     组，路由
        //[Display(Name = "组，路由")]
        public virtual string RouteGroup { get; set; }

        //
        // 摘要:
        //     报文主键，报文标识
        //[Display(Name = "报文主键，报文标识")]
        public virtual string MsgId { get; set; }

        //
        // 摘要:
        //     报文类型
        //[Display(Name = "报文类型")]
        public virtual string MsgType { get; set; }

        //
        // 摘要:
        //     业务主键，数据标识
        //[Display(Name = "业务主键，数据标识")]
        public virtual string BillCode { get; set; }

        //
        // 摘要:
        //     报文内容
        //[Display(Name = "报文内容")]
        public virtual string Content { get; set; }

        //
        // 摘要:
        //     重试次数
        //[Display(Name = "重试次数")]
        public virtual int Retries { get; set; }

        //
        // 摘要:
        //     最后重试时间
        //[Display(Name = "最后重试时间")]
        public virtual DateTime LastRetriesTime { get; set; }

        //
        // 摘要:
        //     备注，处理异常结果
        //[Display(Name = "备注，处理异常结果")]
        public virtual string Remark { get; set; }

        //
        // 摘要:
        //     创建时间
        //[Display(Name = "创建时间")]
        public virtual DateTime CreatedTime { get; set; }

        //
        // 摘要:
        //     过期时间
        //[Display(Name = "过期时间")]
        public virtual DateTime ExpiresAt { get; set; }

        //
        // 摘要:
        //     状态
        //[Display(Name = "状态")]
        public virtual string StatusName { get; set; }

        //
        // 摘要:
        //     发布时间
        //[Display(Name = "发布时间")]
        public virtual DateTime PublishTime { get; set; }

        //
        // 摘要:
        //     是否立即发布
        //[Display(Name = "是否立即发布")]
        public virtual bool ImmediateProcessing { get; set; }

        public CapReceived()
        {
            PublishTime = (CreatedTime = (LastRetriesTime = (ExpiresAt = DateTime.Now)));
            VersionNo = (QueueName = "");
        }
    }