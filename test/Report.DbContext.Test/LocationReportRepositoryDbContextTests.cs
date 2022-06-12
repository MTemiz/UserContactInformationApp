using Microsoft.EntityFrameworkCore;
using Report.Domain.Entities;
using Report.Infrastructure.Context;
using Report.Infrastructure.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;  

namespace Report.DbContext.Test
{
    public class LocationReportRepositoryDbContextTests
    {
        private DbContextOptions<ApplicationDbContext> dbContextOptions;

        public LocationReportRepositoryDbContextTests()
        {
            var dbName = $"PersonContactInfoDb_{DateTime.Now.ToFileTimeUtc()}";
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        private async Task<LocationReportRepository> CreateRepositoryAsync()
        {
            ApplicationDbContext context = new ApplicationDbContext(dbContextOptions);

            await PopulateDataAsync(context);

            return new LocationReportRepository(context);
        }

        private async Task PopulateDataAsync(ApplicationDbContext context)
        {
            int index = 1;

            while (index <= 3)
            {
                var locationReportGuid = Guid.NewGuid();

                var locationReport = new LocationReport()
                {
                    Id = locationReportGuid,
                    State = Domain.Enums.EnmLocationReportState.Preparing,
                    RequestedDate = DateTime.Now
                };

                index++;

                await context.LocationReports.AddAsync(locationReport);
            }

            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task LocationReportRepository_GetAll_IsValid()
        {
            var repository = await CreateRepositoryAsync();

            var personList = await repository.GetAllAsync();

            Assert.Equal(3, personList.Count);
        }

        [Fact]
        public async Task LocationReportRepository_AddAsync_IsValid()
        {
            var repository = await CreateRepositoryAsync();

            var countBeforeAction = (await repository.GetAllAsync()).Count;

            await repository.AddAsync(new LocationReport()
            {
                RequestedDate = DateTime.Now,
                State = Domain.Enums.EnmLocationReportState.Preparing
            });

            var countAfterAction = (await repository.GetAllAsync()).Count;

            Assert.True(countAfterAction > countBeforeAction);
        }

        [Fact]
        public async Task LocationReportRepository_UpdateAsync_IsValid()
        {
            var repository = await CreateRepositoryAsync();

            var beforeUpdatelocationReport = (await repository.GetAllAsync()).First();

            beforeUpdatelocationReport.State = Domain.Enums.EnmLocationReportState.Completed;

            await repository.UpdateAsync(beforeUpdatelocationReport);

            var afterUpdateLocationReport = await repository.GetByIdAsync(beforeUpdatelocationReport.Id);

            Assert.True(beforeUpdatelocationReport.State == afterUpdateLocationReport.State);
        }
    }
}