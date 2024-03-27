using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vermilion.Application.Interfaces;
using Vermilion.Domain.Repositories;

namespace Vermilion.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:pg-connection"];

            services.AddDbContext<VermilionDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IVermilionDbContext>(provider =>
                provider.GetService<VermilionDbContext>()!);

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IRepositoryReadOnly<>), typeof(EfRepository<>));

            return services;
        }
    }
}
