using Microsoft.EntityFrameworkCore;
using PersonContactInfo.Domain.Entities;
using PersonContactInfo.Inftastructure.Context;
using PersonContactInfo.Inftastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PersonContactInfo.DbContext.Test
{
    [CollectionDefinition("Non-Parallel Collection", DisableParallelization = true)]
    public class PersonRepositoryDbContextTests
    {
        private DbContextOptions<ApplicationDbContext> dbContextOptions;

        public PersonRepositoryDbContextTests()
        {
            var dbName = $"PersonContactInfoDb_{DateTime.Now.ToFileTimeUtc()}";
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        private async Task<PersonRepository> CreateRepositoryAsync()
        {
            ApplicationDbContext context = new ApplicationDbContext(dbContextOptions);

            await PopulateDataAsync(context);

            return new PersonRepository(context);
        }

        private async Task PopulateDataAsync(ApplicationDbContext context)
        {
            int index = 1;

            while (index <= 3)
            {
                var personGuid = Guid.NewGuid();

                var person = new Person()
                {
                    Id = personGuid,
                    Name = $"Person_{ index }",
                    Surname = $"Person_{ index }",
                    Company = $"Person_{ index }",
                    CreatedDate = DateTime.Now,
                    Contacts = new List<Contact>()
                     {
                         new Contact()
                         {
                              Id = Guid.NewGuid(),
                              Email = $"Email_{index }",
                              Phone = $"0555777889{index}",
                              Location = $"Person_{index}",
                              PersonId = personGuid
                         }
                    }
                };

                index++;

                await context.Persons.AddAsync(person);
            }

            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task PersonRepository_GetAll_IsValid()
        {
            var repository = await CreateRepositoryAsync();

            var personList = await repository.GetAllAsync();

            Assert.True(personList.Count > 0);
        }

        [Fact]
        public async Task PersonRepository_RemoveAsync_IsValid()
        {
            var repository = await CreateRepositoryAsync();

            var personList = await repository.GetAllAsync();

            var countBeforeAction = personList.Count;

            var person = personList.First();

            await repository.RemoveAsync(person);

            var countAfterAction = (await repository.GetAllAsync()).Count;

            Assert.True(countBeforeAction > countAfterAction);
        }

        [Fact]
        public async Task PersonRepository_AddAsync_IsValid()
        {
            var repository = await CreateRepositoryAsync();

            var countBeforeAction = (await repository.GetAllAsync()).Count;

            await repository.AddAsync(new Person()
            {
                Name = "x",
                Surname = "x",
                Company = "x"
            });

            var countAfterAction = (await repository.GetAllAsync()).Count;

            Assert.True(countAfterAction > countBeforeAction);
        }
    }
}