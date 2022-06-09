using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserContactInformation.Application.Features.Person.Dto;

namespace UserContactInformation.Application.Features.Person.Queries
{
    public class ListPersonsQuery : IRequest<IEnumerable<PersonDto>>
    {
    }
}
