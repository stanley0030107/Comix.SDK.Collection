namespace DotNetCore.CAP.RocketMQ4
{
    public class RocketMQOptions
    {
        public string OnsAccessKey { get; set; }
        public string OnsSecretKey { get; set; }
        public string OnsNameSrv { get; set; }
        public int TopicQueueCount { get; set; } = 99;
        public int ConsumerInterval { get; set; } = 50;

        /// <summary>
        /// 是否记录没有监听的数据
        /// </summary>
        public bool LogNotSubscrib { get; set; } = true;
    }
}