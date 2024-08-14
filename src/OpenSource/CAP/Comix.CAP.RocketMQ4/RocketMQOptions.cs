namespace DotNetCore.CAP.RocketMQ4
{
    public class RocketMQOptions
    {
        public string OnsAccessKey { get; set; }
        public string OnsSecretKey { get; set; }
        public string OnsNameSrv { get; set; }
        public int TopicQueueCount { get; set; } = 99;
        public int ConsumerInterval { get; set; } = 50;
    }
}