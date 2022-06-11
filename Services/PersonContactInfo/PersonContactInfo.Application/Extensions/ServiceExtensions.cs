using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PersonContactInfo.Application.Features.Contact.Dtos;
using PersonContactInfo.Application.Features.Person.Queries;
using System.Reflection;
using UserContactInformation.Application.Features.Contact.Commands;
using UserContactInformation.Application.Features.Person.Commands;
using UserContactInformation.Application.Features.Person.Dtos;
using UserContactInformation.Application.Features.Person.Queries;

namespace PersonContactInfo.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped(typeof(IRequestHandler<AddContactCommand, ContactDto>), typeof(AddContactCommandHandler));
            services.AddScoped(typeof(IRequestHandler<RemoveContactCommand, int>), typeof(RemoveContactCommandHandler));

            services.AddScoped(typeof(IRequestHandler<AddPersonCommand, PersonDto>), typeof(AddPersonCommandHandler));
            services.AddScoped(typeof(IRequestHandler<RemovePersonCommand, int>), typeof(RemovePersonCommandHandler));

            services.AddScoped(typeof(IRequestHandler<GetPersonDetailsByIdQuery, PersonDto>), typeof(GetPersonDetailsByIdQueryHandler));
            services.AddScoped(typeof(IRequestHandler<ListPersonsQuery, List<PersonDto>>), typeof(ListPersonsQueryHandler));
        }
    }
}
