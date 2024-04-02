using MediatR;
using Serilog;
using Vermilion.Application;
using Vermilion.Application.Behaviors;
using Vermilion.Contracts;
using Vermilion.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration);
});

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddContracts();
services.AddApplication();
services.AddInfrastructure(configuration);

services.AddRouting(options => options.LowercaseUrls = true);
services.AddResponseCompression();

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

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
