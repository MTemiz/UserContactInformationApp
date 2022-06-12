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
    public class RemoveContactCommandHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IContactRepository> mockPersonRepository;

        public RemoveContactCommandHandlerTest()
        {
            mockPersonRepository = MockContactRepository.GetRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ContactMappingProfile>();
            });

            mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task RemoveContactCommandHandler_WhenNotExistsPersonId_ThrowsNotFoundException()
        {
            var handler = new RemoveContactCommandHandler(mockPersonRepository.Object, mapper);

            var command = new RemoveContactCommand()
            {
                Id = Guid.NewGuid()
            };

            await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task RemoveContactCommandHandler_WhenExistsPersonId_ReturnsValid()
        {
            var handler = new RemoveContactCommandHandler(mockPersonRepository.Object, mapper);

            var command = new RemoveContactCommand()
            {
                Id = Guid.Parse("adb086c6-7984-423f-a275-9b027e94f4e6")
            };

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.Equal(0, result);
        }
    }
}
