using AutoMapper;
using Moq;
using Report.Application.Exceptions;
using Report.Application.Features.LocationReport.Queries;
using Report.Application.Interfaces.Repositories;
using Report.Application.MappingProfiles;
using Report.Application.Test.Mocks;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Report.Application.Test.Features.LocationReport.Queries
{
    public class GetLocationReportDetailsByIdQueryHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<ILocationReportRepository> mockLocationReportRepository;

        public GetLocationReportDetailsByIdQueryHandlerTest()
        {
            mockLocationReportRepository = MockLocationReportRepository.GetRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<LocationReportMappingProfile>();
                c.AddProfile<LocationReportResultMappingProfile>();
            });

            mapper = mapperConfig.CreateMapper();
        }


        [Fact]
        public async Task GetLocationReportDetailsByIdQueryHandler_WhenNotExistsId_ThrowsNotFoundException()
        {
            var handler = new GetLocationReportDetailsByIdQueryHandler(mockLocationReportRepository.Object, mapper);

            var query = new GetLocationReportDetailsByIdQuery() { Id = Guid.NewGuid() };

            await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(query, CancellationToken.None));
        }

        [Fact]
        public async Task GetLocationReportDetailsByIdQueryHandler_WhenExistsId_ReturnsValid()
        {
            var handler = new GetLocationReportDetailsByIdQueryHandler(mockLocationReportRepository.Object, mapper);

            var query = new GetLocationReportDetailsByIdQuery() { Id = Guid.Parse("277b6255-26d7-4de3-807e-9597dab2e157") };

            var result = await handler.Handle(query, CancellationToken.None);

            mockLocationReportRepository.Verify(c => c.GetByIdWithResultsAsync(It.IsAny<Guid>()), Times.Once);

            mockLocationReportRepository.VerifyNoOtherCalls();

            Assert.Equal(result.Id, query.Id);
        }
    }
}
