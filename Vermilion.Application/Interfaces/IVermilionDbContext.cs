using Microsoft.EntityFrameworkCore;
using Vermilion.Domain.Entities;

namespace Vermilion.Application.Interfaces
{
    public interface IVermilionDbContext
    {
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Catering> Caterings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkSchedule> WorkSchedules { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
