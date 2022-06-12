using EventBus.Base.Abstraction;
using EventBus.Base.Events;
using Moq;
using Report.Application.IntegrationEvents;

namespace Report.Application.Test.Mocks
{
    public class MockEventBus
    {
        public static Mock<IEventBus> GetEventBus()
        {
            var mockRepo = new Mock<IEventBus>();

            mockRepo.Setup(x => x.Publish(It.IsAny<IntegrationEvent>()));

            return mockRepo;
        }
    }
}
