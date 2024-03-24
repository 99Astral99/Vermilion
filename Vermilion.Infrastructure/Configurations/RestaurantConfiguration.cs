using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vermilion.Domain.Entities;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Infrastructure.Configurations
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasConversion(
                restaurantId => restaurantId.ToString(),
                value => new RestaurantId(value));

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(100);
            builder.Property(p => p.Email).HasMaxLength(100);
            builder.Property(p => p.Phone).HasMaxLength(100);

            builder.HasMany(m => m.Menus)
                .WithOne()
                .HasForeignKey(x => x.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Reviews)
                .WithOne()
                .HasForeignKey(r => r.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(w => w.WorkSchedules)
                .WithOne()
                .HasForeignKey(w => w.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Cuisines)
                .WithMany();

            builder.HasMany(f => f.Features)
                .WithMany();

            builder.ComplexProperty(x => x.Address).IsRequired();
        }
    }
}
