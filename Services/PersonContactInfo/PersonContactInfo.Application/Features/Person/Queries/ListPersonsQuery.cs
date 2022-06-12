using MediatR;
using PersonContactInfo.Application.Features.Person.Dtos;

namespace PersonContactInfo.Application.Features.Person.Queries
{
    public class ListPersonsQuery : IRequest<List<PersonDto>>
    {
    }
}
