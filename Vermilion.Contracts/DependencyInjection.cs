using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Vermilion.Contracts
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddContracts(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
