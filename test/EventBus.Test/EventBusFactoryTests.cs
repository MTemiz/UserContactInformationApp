using EventBus.Base;
using EventBus.Base.Constants;
using EventBus.Factory;
using RabbitMQ.Client;
using System;
using Xunit;

namespace EventBus.Test
{
    public class EventBusFactoryTests
    {
        [Theory]
        [InlineData(EventBusType.KafkaMQ)]
        [InlineData(EventBusType.ActiveMQ)]
        [InlineData(EventBusType.AzureMQ)]
        public void EventBus_WhenBusTypeIsNotRabbit_ThrowsNotImplementedException(EventBusType busType)
        {
            EventBusConfig config = new()
            {
                ConnectionRetryCount = 5,
                SubscriberClientName = "PersonContactService",
                HostName = "localhost",
                EventBusType = busType,
            };
            Assert.Throws<NotImplementedException>(() => EventBusFactory.Create(config, null));
        }
    }
}