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
    public class ContactRepositoryDbContextTests
    {
        private DbContextOptions<ApplicationDbContext> dbContextOptions;

        public ContactRepositoryDbContextTests()
        {
            var dbName = $"PersonContactInfoDb_{DateTime.Now.ToFileTimeUtc()}";
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        private async Task<ContactRepository> CreateRepositoryAsync()
        {
            ApplicationDbContext context = new ApplicationDbContext(dbContextOptions);

            await PopulateDataAsync(context);

            return new ContactRepository(context);
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
        public async Task ContactRepository_GetAll_IsValid()
        {
            var repository = await CreateRepositoryAsync();

            var contactList = await repository.GetAllAsync();

            Assert.True(contactList.Count > 0);
        }

        [Fact]
        public async Task ContactRepository_RemoveAsync_IsValid()
        {
            var repository = await CreateRepositoryAsync();

            var contacts = await repository.GetAllAsync();

            var countBeforeAction = contacts.Count;

            var contact = contacts.First();

            await repository.RemoveAsync(contact);

            var countAfterAction = (await repository.GetAllAsync()).Count;

            Assert.True(countBeforeAction > countAfterAction);
        }

        [Fact]
        public async Task ContactRepository_AddAsync_IsValid()
        {
            var repository = await CreateRepositoryAsync();

            var contactList = await repository.GetAllAsync();

            var countBeforeAction = contactList.Count();

            var contact = contactList.First();

            await repository.AddAsync(new Contact()
            {
                Id = Guid.NewGuid(),
                PersonId = contact.PersonId,
                Email = "x@x.com",
                Location = "Ankara",
                Phone = "5559992211"
            });

            var countAfterAction = (await repository.GetAllAsync()).Count;

            Assert.True(countBeforeAction < countAfterAction);
        }
    }
}
