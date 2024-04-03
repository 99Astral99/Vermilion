using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Vermilion.Application.Common.MapProfiles;

namespace Vermilion.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(typeof(MapProfileCategory));
            });

            return services;
        }
    }
}
