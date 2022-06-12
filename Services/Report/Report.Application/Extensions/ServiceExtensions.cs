using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Base.Constants;
using EventBus.Factory;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using Report.Application.Features.LocationReport.Commands;
using Report.Application.Features.LocationReport.Dtos;
using Report.Application.Features.LocationReport.Queries;
using Report.Application.IntegrationEvents;
using System.Reflection;

namespace Report.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomMediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IRequestHandler<RequestLocationReportCommand, LocationReportDto>), typeof(RequestLocationReportCommandHandler));
            services.AddScoped(typeof(IRequestHandler<GetLocationReportDetailsByIdQuery, LocationReportDetailDto>), typeof(GetLocationReportDetailsByIdQueryHandler));
            services.AddScoped(typeof(IRequestHandler<ListLocationReportsQuery, IEnumerable<LocationReportDto>>), typeof(ListLocationReportsQueryHandler));
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
            services.AddScoped<LocationReportGeneratedIntegrationEventHandler>();
        }
    }
}
