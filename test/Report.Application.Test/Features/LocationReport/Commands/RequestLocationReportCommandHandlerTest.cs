using AutoMapper;
using EventBus.Base.Abstraction;
using EventBus.Base.Events;
using Moq;
using Report.Application.Features.LocationReport.Commands;
using Report.Application.Interfaces.Repositories;
using Report.Application.MappingProfiles;
using Report.Application.Test.Mocks;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Report.Application.Test.Features.LocationReport.Commands
{
    public class RequestLocationReportCommandHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<ILocationReportRepository> locationReportRepository;
        private readonly Mock<IEventBus> eventBus;

        public RequestLocationReportCommandHandlerTest()
        {
            locationReportRepository = MockLocationReportRepository.GetRepository();

            eventBus = MockEventBus.GetEventBus();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<LocationReportMappingProfile>();
            });

            mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task RequestLocationReportCommandHandler_WhenAddReport_ReturnsValidAndHitsEventBus()
        {
            eventBus.Verify();

            var handler = new RequestLocationReportCommandHandler(locationReportRepository.Object, mapper, eventBus.Object);

            var command = new RequestLocationReportCommand();

            var result = await handler.Handle(command, CancellationToken.None);

            eventBus.Verify(c => c.Publish(It.IsAny<IntegrationEvent>()), Times.Once);

            Assert.NotNull(result.State);
            Assert.True(result.RequestedDate.Date == DateTime.Now.Date);
        }

        [Fact]
        public async Task RequestLocationReportCommandHandler_WhenAddReport_StateIsPreparing()
        {
            eventBus.Verify();

            var handler = new RequestLocationReportCommandHandler(locationReportRepository.Object, mapper, eventBus.Object);

            var command = new RequestLocationReportCommand();

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.Equal("Preparing", result.State);
        }
    }
}
