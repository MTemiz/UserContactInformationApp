using Moq;
using PersonContactInfo.Application.Exceptions;
using PersonContactInfo.Application.Features.Person.Commands;
using PersonContactInfo.Application.Interface.Repository;
using PersonContactInfo.Application.Test.Mocks;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PersonContactInfo.Application.Test.Features.Person.Commands
{
    public class RemovePersonCommandHandlerTest
    {
        private readonly Mock<IPersonRepository> mockPersonRepository;

        public RemovePersonCommandHandlerTest()
        {
            mockPersonRepository = MockPersonRepository.GetRepository();
        }

        [Fact]
        public async Task RemovePersonCommandHandler_WhenNotExistsId_ThrowsNotFoundException()
        {
            var handler = new RemovePersonCommandHandler(mockPersonRepository.Object);

            await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(new RemovePersonCommand() { Id = Guid.NewGuid() }, CancellationToken.None));
        }

        [Fact]
        public async Task RemovePersonCommandHandler_WhenExistsId_ReturnsValid()
        {
            var handler = new RemovePersonCommandHandler(mockPersonRepository.Object);

            var guid = Guid.Parse("99c4a2ab-c8b9-4a69-bfeb-d08ccb26a2b7");

            var result = await handler.Handle(new RemovePersonCommand() { Id = guid }, CancellationToken.None);

            Assert.Equal(0, result);
        }
    }
}
