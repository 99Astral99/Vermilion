using Microsoft.EntityFrameworkCore;
using Vermilion.Application.Interfaces;
using Vermilion.Domain.Entities;
using Vermilion.Infrastructure.Configurations;
using Vermilion.Infrastructure.Interceptors;

namespace Vermilion.Infrastructure
{
    public class VermilionDbContext : DbContext, IVermilionDbContext
    {
        public VermilionDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new DataInterceptor());
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(VermilionDbContext).Assembly);
        }

        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkSchedule> WorkSchedules { get; set; }
    }
}
