﻿using EventBus.Base.Constants;

namespace EventBus.Base
{
    public class EventBusConfig
    {

        public int ConnectionRetryCount { get; set; } = 3;

        public string DefaultTopicName { get; set; } = "LocationReportTopic";

        public string EventBusConnectionString { get; set; }

        public string SubscriberClientName { get; set; }

        public EventBusType EventBusType { get; set; } = EventBusType.RabbitMQ;

        public string HostName { get; set; }

        public object Connection { get; set; }
    }
}
