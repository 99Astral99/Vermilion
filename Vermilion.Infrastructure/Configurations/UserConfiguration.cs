using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vermilion.Domain.Entities;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasConversion(
                userId => userId.ToString(),
                value => new UserId(value));

            builder.HasIndex(e => e.Email).IsUnique();
            builder.Property(p => p.Email).IsRequired();

            builder.Property(x => x.Id).HasConversion(
                restaurantId => restaurantId.ToString(),
                value => new UserId(value));

            builder.HasMany(r => r.Reviews)
                .WithOne()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
