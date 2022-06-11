using MediatR;
using PersonContactInfo.Application.Features.Person.Dtos;

namespace PersonContactInfo.Application.Features.Person.Queries
{
    public class GetPersonDetailsByIdQuery : IRequest<PersonDto>
    {
        public Guid Id { get; set; }
    }
}
