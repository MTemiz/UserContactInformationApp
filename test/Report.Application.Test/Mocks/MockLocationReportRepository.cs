using Moq;
using Report.Application.Interfaces.Repositories;
using Report.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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

            mockRepo.Setup(c => c.AddAsync(It.IsAny<LocationReport>())).ReturnsAsync((LocationReport locationReport) =>
            {
                locationReport.Id = Guid.NewGuid();
                locationReports.Add(locationReport);
                return 0;
            });

            mockRepo.Setup(c => c.GetAll()).Returns(locationReports.AsQueryable());

            mockRepo.Setup(c => c.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Guid id) =>
            {
                return locationReports.FirstOrDefault(c => c.Id == id);
            });

            mockRepo.Setup(c => c.GetByIdWithResultsAsync(It.IsAny<Guid>())).ReturnsAsync((Guid guid) =>
            {
                return locationReportsWithResults.FirstOrDefault(c => c.Id == guid);
            });

            return mockRepo;
        }
    }
}
