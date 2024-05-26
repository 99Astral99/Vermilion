using MassTransit;
using MediatR;
using Microsoft.Extensions.Options;
using Serilog;
using Vermilion.Application;
using Vermilion.Application.Common.Abstractions.EventBus;
using Vermilion.Application.Common.Behaviors;
using Vermilion.Application.Handlers.Reviews;
using Vermilion.Contracts;
using Vermilion.Infrastructure;
using Vermilion.Infrastructure.MessageBroker;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

//builder.Host.UseSerilog((context, config) =>
//{
//    config.ReadFrom.Configuration(context.Configuration);
//});

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddContracts();
services.AddApplication();
services.AddInfrastructure(configuration);

services.AddRouting(options => options.LowercaseUrls = true);
services.AddResponseCompression();


services.Configure<MessageBrokerSettings>(
    configuration.GetSection("MessageBroker"));

services.AddSingleton(sp => sp.GetRequiredService<IOptions<MessageBrokerSettings>>().Value);

services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();

    busConfigurator.AddConsumer<ReviewCreatedEventConsumer>();

    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        MessageBrokerSettings settings = context.GetRequiredService<MessageBrokerSettings>();

        configurator.Host(new Uri(settings.Host), h =>
        {
            h.Username(settings.Username);
            h.Password(settings.Password);
        });

        configurator.ReceiveEndpoint("ReviewCreatedEventQueue", e =>
        {
            e.ConfigureConsumer<ReviewCreatedEventConsumer>(context);
        });
    });
});

builder.Services.AddTransient<IEventBus, EventBus>();

services.AddStackExchangeRedisCache(opt =>
opt.Configuration = builder.Configuration.GetConnectionString("redis"));

services.AddScoped(typeof(IPipelineBehavior<,>),
    typeof(LoggingPipelineBehavior<,>));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<VermilionDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception)
    {
        throw;
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DisplayRequestDuration();
    });
}

//app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
