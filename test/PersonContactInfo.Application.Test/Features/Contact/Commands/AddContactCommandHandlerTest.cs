using AutoMapper;
using Moq;
using PersonContactInfo.Application.Exceptions;
using PersonContactInfo.Application.Features.Contact.Commands;
using PersonContactInfo.Application.Interface.Repository;
using PersonContactInfo.Application.MappingProfiles;
using PersonContactInfo.Application.Test.Mocks;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PersonContactInfo.Application.Test.Features.Contact.Commands
{
    public class AddContactCommandHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IContactRepository> mockContactRepository;
        private readonly Mock<IPersonRepository> mockPersonRepository;

        public AddContactCommandHandlerTest()
        {
            mockContactRepository = MockContactRepository.GetRepository();

            mockPersonRepository = MockPersonRepository.GetRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ContactMappingProfile>();
                c.AddProfile<PersonMappingProfile>();
            });

            mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task AddContactCommandHandler_WhenWithExistsPersonId_ReturnsValid()
        {
            var handler = new AddContactCommandHandler(mockContactRepository.Object, mapper, mockPersonRepository.Object);

            var command = new AddContactCommand()
            {
                PersonId = Guid.Parse("99c4a2ab-c8b9-4a69-bfeb-d08ccb26a2b7"),
                Email = "test@test.com",
                Location = "Reykjavik",
                Phone = "9874563210"
            };

            var result = await handler.Handle(command, CancellationToken.None);

            mockContactRepository.Verify(c => c.AddAsync(It.IsAny<Domain.Entities.Contact>()), Times.Once);

            mockPersonRepository.Verify(c => c.GetByIdAsync(It.IsAny<Guid>()), Times.Once);

            mockContactRepository.VerifyNoOtherCalls();

            Assert.NotNull(result);
            Assert.Equal(result.Email, command.Email);
            Assert.Equal(result.Location, command.Location);
            Assert.Equal(result.Phone, command.Phone);
            Assert.Equal(result.PersonId, command.PersonId);
        }

        [Fact]
        public async Task AddContactCommandHandler_WhenNotExistsPersonId_ThrowsNotFoundException()
        {
            var handler = new AddContactCommandHandler(mockContactRepository.Object, mapper, mockPersonRepository.Object);

            var command = new AddContactCommand()
            {
                PersonId = Guid.NewGuid(),
                Email = "test@test.com",
                Location = "Reykjavik",
                Phone = "9874563210"
            };

            await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(command, CancellationToken.None));
        }
    }
}
