using EventBus.Base.Abstraction;
using EventBus.Base.Events;
using EventBus.Base.SubManagers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EventBus.Test
{
    public class TestIntegrationEvent : IntegrationEvent { }
    public class TestIntegrationEventHandler : IIntegrationEventHandler<TestIntegrationEvent>
    {
        public Task Handle(TestIntegrationEvent @event)
        {
            throw new NotImplementedException();
        }
    }

    public class InMemoryEventBusSubscriptionManagerTests
    {
        [Fact]
        public void SubManager_HasNewSubscriptionForEventType_Valid()
        {
            var subscriptionManager = new InMemoryEventBusSubscriptionManager();

            subscriptionManager.AddSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();

            bool result = subscriptionManager.HasSubscriptionForEvent<TestIntegrationEvent>();

            Assert.True(result);
        }

        [Fact]
        public void SubManager_HasNewSubscriptionForEventName_Valid()
        {
            var subscriptionManager = new InMemoryEventBusSubscriptionManager();

            subscriptionManager.AddSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();

            bool result = subscriptionManager.HasSubscriptionForEvent(typeof(TestIntegrationEvent).Name);

            Assert.True(result);
        }

        [Fact]
        public void SubManager_HasNewSubscriptionForEvent_GetEventNameIsValid()
        {
            var subscriptionManager = new InMemoryEventBusSubscriptionManager();

            subscriptionManager.AddSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();

            string result = subscriptionManager.GetEventName<TestIntegrationEvent>();

            Assert.Equal(result, typeof(TestIntegrationEvent).Name);
        }

        [Fact]
        public void SubManager_HasNewSubscriptionForEvent_GetEventByTypeNameIsValid()
        {
            var subscriptionManager = new InMemoryEventBusSubscriptionManager();

            subscriptionManager.AddSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();

            Type result = subscriptionManager.GetEventTypeByName(typeof(TestIntegrationEvent).Name);

            Assert.Equal(typeof(TestIntegrationEvent), result);
        }

        [Fact]
        public void SubManager_WhenHandlersCountEqualToZero_IsEmpty()
        {
            var subscriptionManager = new InMemoryEventBusSubscriptionManager();

            subscriptionManager.AddSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();

            subscriptionManager.Clear();

            Assert.True(subscriptionManager.IsEmpty);
        }

        [Fact]
        public void SubManager_WhenHandlersCountGreaterThanZero_IsNotEmpty()
        {
            var subscriptionManager = new InMemoryEventBusSubscriptionManager();

            subscriptionManager.AddSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();

            Assert.False(subscriptionManager.IsEmpty);
        }

        [Fact]
        public void SubManager_WhenDuplicateSubscription_ThrowsArgumentException()
        {
            var subscriptionManager = new InMemoryEventBusSubscriptionManager();

            subscriptionManager.AddSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();

            Assert.Throws<ArgumentException>(() =>
            {
                subscriptionManager.AddSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();
            });
        }
    }
}
