using EventBus.Base.Constants;

namespace EventBus.Base
{
    public class EventBusConfig
    {

        public int ConnectionRetryCount { get; set; } = 3;

        public string DefaultTopicName { get; set; }

        public string SubscriberClientName { get; set; }

        public EventBusType EventBusType { get; set; }

        public string HostName { get; set; }
        public int Port { get; set; }
    }
}
