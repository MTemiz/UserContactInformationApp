using AutoMapper;
using Moq;
using Report.Application.Features.LocationReport.Queries;
using Report.Application.Interfaces.Repositories;
using Report.Application.MappingProfiles;
using Report.Application.Test.Mocks;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Report.Application.Test.Features.LocationReport.Queries
{
    public class ListLocationReportsQueryHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<ILocationReportRepository> mockLocationReportRepository;

        public ListLocationReportsQueryHandlerTest()
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
        public async Task GetLocationReportDetailsByIdQueryHandler_ReturnsValid()
        {
            var handler = new ListLocationReportsQueryHandler(mockLocationReportRepository.Object, mapper);

            var query = new ListLocationReportsQuery();

            var result = await handler.Handle(query, CancellationToken.None);

            mockLocationReportRepository.Verify(c => c.GetAllAsync(), Times.Once);

            mockLocationReportRepository.VerifyNoOtherCalls();

            Assert.NotNull(result);

            Assert.Equal(2, result.Count());
        }
    }
}
