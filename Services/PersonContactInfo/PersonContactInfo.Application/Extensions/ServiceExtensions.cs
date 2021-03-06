using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Factory;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PersonContactInfo.Application.Features.Contact.Commands;
using PersonContactInfo.Application.Features.Contact.Dtos;
using PersonContactInfo.Application.Features.Person.Commands;
using PersonContactInfo.Application.Features.Person.Dtos;
using PersonContactInfo.Application.Features.Person.Queries;
using PersonContactInfo.Application.IntegrationEvents;
using RabbitMQ.Client;
using System.Reflection;

namespace PersonContactInfo.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomMediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(IRequestHandler<AddContactCommand, ContactDto>), typeof(AddContactCommandHandler));
            services.AddScoped(typeof(IRequestHandler<RemoveContactCommand, int>), typeof(RemoveContactCommandHandler));

            services.AddScoped(typeof(IRequestHandler<AddPersonCommand, PersonDto>), typeof(AddPersonCommandHandler));
            services.AddScoped(typeof(IRequestHandler<RemovePersonCommand, int>), typeof(RemovePersonCommandHandler));

            services.AddScoped(typeof(IRequestHandler<GetPersonDetailsByIdQuery, PersonContactDto>), typeof(GetPersonDetailsByIdQueryHandler));
            services.AddScoped(typeof(IRequestHandler<ListPersonsQuery, List<PersonDto>>), typeof(ListPersonsQueryHandler));
        }

        public static void AddCustomAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void AddCustomEventBus(this IServiceCollection services)
        {
            services.AddSingleton<IEventBus>(sp =>
            {
                var config = sp.GetRequiredService<EventBusConfig>();

                return EventBusFactory.Create(config, sp);
            });
        }

        public static void AddCustomEventBusHandlers(this IServiceCollection services)
        {
            services.AddScoped<LocationReportRequestedIntegrationEventHandler>();
        }
    }
}
