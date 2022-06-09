using MediatR;
using UserContactInformation.Application.Features.Person.Dtos;

namespace UserContactInformation.Application.Features.Person.Queries
{
    public class ListPersonsQuery : IRequest<IEnumerable<PersonDto>>
    {
    }
}
