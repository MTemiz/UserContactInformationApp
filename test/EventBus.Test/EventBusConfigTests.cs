using EventBus.Base;
using EventBus.Base.Constants;
using Xunit;

namespace EventBus.Test
{
    public class EventBusConfigTests
    {
        [Fact]
        public void EventBusConfig_HostName_DefaultLocationReportTopic()
        {
            var cfg = new EventBusConfig();
            Assert.Equal("LocationReportTopic", cfg.DefaultTopicName);
        }

        [Fact]
        public void EventBusConfig_HostName_DefaultEventBusTypeIsRabbitMQ()
        {
            var cfg = new EventBusConfig();

            Assert.Equal(EventBusType.RabbitMQ, cfg.EventBusType);
        }
    }
}
