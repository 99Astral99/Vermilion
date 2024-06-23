using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vermilion.Application;
using Vermilion.Application.Interfaces;
using Vermilion.Domain.Repositories;
using Vermilion.Infrastructure;

namespace Vermilion.ApplicationTests.Common
{
    public class ApplicationFixture
    {
        public ApplicationFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped(typeof(IRepositoryReadOnly<>), typeof(EfRepository<>));
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            serviceCollection.AddDbContext<VermilionDbContext>(
                opt => opt.UseInMemoryDatabase("TestDb"));
            serviceCollection.AddScoped<IVermilionDbContext>(provider =>
                provider.GetService<VermilionDbContext>()!);
            serviceCollection.AddDistributedMemoryCache();

            serviceCollection.AddApplication();

            _serviceProvider = serviceCollection.BuildServiceProvider();
            _serviceProvider.GetRequiredService<VermilionDbContext>();
        }

        private readonly ServiceProvider _serviceProvider;
        public IMediator Mediator => _serviceProvider.GetRequiredService<IMediator>();
    }
}
