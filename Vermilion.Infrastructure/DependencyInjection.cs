using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vermilion.Application.Interfaces;

namespace Vermilion.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:pg-connection"];

            services.AddDbContext<VermilionDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });


            services.AddScoped<IVermilionDbContext>(provider =>
                provider.GetService<VermilionDbContext>()!);

            return services;
        }
    }
}
