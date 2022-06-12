using Moq;
using Report.Application.Interfaces.Repositories;
using Report.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.Application.Test.Mocks
{
    public class MockLocationReportRepository
    {
        public static Mock<ILocationReportRepository> GetRepository()
        {
            var locationReports = new List<LocationReport>()
            {
                new LocationReport(){
                    Id = Guid.Parse("95bf8836-072e-4867-9094-a7389679b9b1"),
                    RequestedDate=DateTime.Now,
                    State = Domain.Enums.EnmLocationReportState.Preparing,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = null},

               new LocationReport(){
                    Id = Guid.Parse("95bf8836-072e-4867-9094-a7389679b9b1"),
                    RequestedDate=DateTime.Now,
                    State = Domain.Enums.EnmLocationReportState.Preparing,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = null},
            };

            var locationReportsWithResults = new List<LocationReport>()
            {
                new LocationReport(){
                    Id = Guid.Parse("277b6255-26d7-4de3-807e-9597dab2e157"),
                    RequestedDate=DateTime.Now,
                    State = Domain.Enums.EnmLocationReportState.Completed,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = null,
                    ReportResults=new List<LocationReportResult>(){
                      new LocationReportResult()
                      {
                           Id = Guid.Parse("6e972d22-9886-49e8-b3a6-2a542619aab1"),
                           LocationReportId = Guid.Parse("277b6255-26d7-4de3-807e-9597dab2e157"),
                           Location="Ankara",
                           PersonCount = 2,
                           PhoneNumberCount = 2,
                           CreatedDate = DateTime.Now
                      },
                      new LocationReportResult()
                      {
                           Id = Guid.Parse("f19594eb-eddf-4568-9135-e1d8d586eda7"),
                           LocationReportId = Guid.Parse("277b6255-26d7-4de3-807e-9597dab2e157"),
                           Location="Bursa",
                           PersonCount = 2,
                           PhoneNumberCount = 2,
                           CreatedDate = DateTime.Now
                      }
                    }
                }
            };

            var mockRepo = new Mock<ILocationReportRepository>();

            mockRepo.Setup(x => x.AddAsync(It.IsAny<Domain.Entities.LocationReport>()))
            .Returns(new Func<LocationReport, Task>(
                locationReport =>
                {
                    locationReport.Id = Guid.NewGuid();
                    locationReports.Add(locationReport);

                    return Task.CompletedTask;
                }));

            mockRepo.Setup(x => x.GetByIdWithResultsAsync(It.IsAny<Guid>()))
           .Returns(new Func<Guid, Task<LocationReport?>>(
            guid =>
            {
                return Task.FromResult(locationReportsWithResults.FirstOrDefault(c => c.Id == guid));
            }));

            mockRepo.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(locationReports));

            mockRepo.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
           .Returns(new Func<Guid, Task<LocationReport?>>(
            guid =>
            {
                return Task.FromResult(locationReports.FirstOrDefault(c => c.Id == guid));
            }));

            return mockRepo;
        }
    }
}
