using AutoMapper;
using Moq;
using PersonContactInfo.Application.Features.Person.Commands;
using PersonContactInfo.Application.Interface.Repository;
using PersonContactInfo.Application.MappingProfiles;
using PersonContactInfo.Application.Test.Mocks;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PersonContactInfo.Application.Test.Features.Person.Commands
{
    public class AddPersonCommandHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IPersonRepository> mockPersonRepository;

        public AddPersonCommandHandlerTest()
        {
            mockPersonRepository = MockPersonRepository.GetRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<PersonMappingProfile>();
            });

            mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task AddPersonCommandHandler_WhenAddPerson_ReturnsValid()
        {
            var handler = new AddPersonCommandHandler(mockPersonRepository.Object, mapper);

            var command = new AddPersonCommand()
            {
                Name = "X",
                Surname = "Y",
                Company = "Z"
            };

            var result = await handler.Handle(command, CancellationToken.None);

            mockPersonRepository.Verify(c => c.AddAsync(It.IsAny<Domain.Entities.Person>()), Times.Once);

            mockPersonRepository.VerifyNoOtherCalls();
        }
    }
}
