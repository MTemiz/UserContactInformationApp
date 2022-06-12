using AutoMapper;
using Moq;
using PersonContactInfo.Application.Exceptions;
using PersonContactInfo.Application.Features.Person.Queries;
using PersonContactInfo.Application.Interface.Repository;
using PersonContactInfo.Application.MappingProfiles;
using PersonContactInfo.Application.Test.Mocks;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PersonContactInfo.Application.Test.Features.Person.Queries
{
    public class GetPersonDetailsByIdQueryHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IPersonRepository> mockPersonRepository;

        public GetPersonDetailsByIdQueryHandlerTest()
        {
            mockPersonRepository = MockPersonRepository.GetRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<PersonMappingProfile>();
            });

            mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetPersonDetailsQueryHandler_WhenNotExistsId_ThrowsNotFoundException()
        {
            var handler = new GetPersonDetailsByIdQueryHandler(mockPersonRepository.Object, mapper);

            await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(new GetPersonDetailsByIdQuery() { Id = Guid.NewGuid() }, CancellationToken.None));
        }

        [Fact]
        public async Task GetPersonDetailsQueryHandler_WhenExistsId_ReturnsValid()
        {
            var handler = new GetPersonDetailsByIdQueryHandler(mockPersonRepository.Object, mapper);

            var guid = Guid.Parse("99c4a2ab-c8b9-4a69-bfeb-d08ccb26a2b7");

            var result = await handler.Handle(new GetPersonDetailsByIdQuery() { Id = guid }, CancellationToken.None);

            Assert.Equal(result.Id, guid);
        }
    }
}
