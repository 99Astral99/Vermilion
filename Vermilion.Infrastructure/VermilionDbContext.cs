using MediatR;
using Microsoft.EntityFrameworkCore;
using Vermilion.Application.Interfaces;
using Vermilion.Domain.Common;
using Vermilion.Domain.Entities;
using Vermilion.Infrastructure.Interceptors;

namespace Vermilion.Infrastructure
{
    public class VermilionDbContext : DbContext, IVermilionDbContext
    {
        private readonly IPublisher _publisher;
        public VermilionDbContext(DbContextOptions options, IPublisher publisher) : base(options)
        {
            _publisher = publisher;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new DataInterceptor());
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(VermilionDbContext).Assembly);
        }

        public DbSet<CateringImage> CateringImages { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Catering> Caterings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkSchedule> WorkSchedules { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var domainEvents = ChangeTracker.Entries<Entity<object>>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .SelectMany(e => e.DomainEvents);

            var result = await base.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }
            return result;
        }
    }
}
