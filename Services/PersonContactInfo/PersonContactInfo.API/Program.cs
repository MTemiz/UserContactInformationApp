using EventBus.Base;
using Microsoft.Extensions.Options;
using PersonContactInfo.API.Extensions;
using PersonContactInfo.API.Middlewares;
using PersonContactInfo.Application.Extensions;
using PersonContactInfo.Inftastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<EventBusConfig>(builder.Configuration.GetSection("RabbitMqConnection"));

builder.Services.AddSingleton<EventBusConfig>(c =>
{
    return c.GetRequiredService<IOptions<EventBusConfig>>().Value;
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomDbContext(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddCustomMediatR();
builder.Services.AddCustomAutoMapper();
builder.Services.AddCustomEventBus();
builder.Services.AddCustomEventBusHandlers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.SubscribeEventBus();
app.DatabaseMigrate();
app.UseMiddleware<ExceptionMiddleware>();

app.Run();
