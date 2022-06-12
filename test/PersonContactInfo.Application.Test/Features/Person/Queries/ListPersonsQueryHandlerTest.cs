using AutoMapper;
using Moq;
using PersonContactInfo.Application.Features.Person.Dtos;
using PersonContactInfo.Application.Features.Person.Queries;
using PersonContactInfo.Application.Interface.Repository;
using PersonContactInfo.Application.MappingProfiles;
using PersonContactInfo.Application.Test.Mocks;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PersonContactInfo.Application.Test.Features.Person.Queries
{
    public class ListPersonsQueryHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IPersonRepository> mockPersonRepository;

        public ListPersonsQueryHandlerTest()
        {
            mockPersonRepository = MockPersonRepository.GetRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<PersonMappingProfile>();
            });

            mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task ListPersonsQueryHandler_WhenGetAll_ReturnsValid()
        {
            var handler = new ListPersonsQueryHandler(mockPersonRepository.Object, mapper);

            var result = await handler.Handle(new ListPersonsQuery(), CancellationToken.None);

            mockPersonRepository.Verify(c => c.GetAllAsync(), Times.Once);

            mockPersonRepository.VerifyNoOtherCalls();

            result.ShouldBeOfType<List<PersonDto>>();

            result.Count.ShouldBeGreaterThan(0);
        }
    }
}
