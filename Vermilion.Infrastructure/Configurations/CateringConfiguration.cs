using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vermilion.Domain.Entities;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Infrastructure.Configurations
{
    public class CateringConfiguration : IEntityTypeConfiguration<Catering>
    {
        public void Configure(EntityTypeBuilder<Catering> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasIndex(x => x.Address).IsUnique();

            builder.Property(x => x.Id).HasConversion(
                restaurantId => restaurantId.Value,
                value => new CateringId(value));

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(x => x.Address).HasMaxLength(500);
            builder.Property(p => p.AverageRating).HasDefaultValue(0);

            builder.ComplexProperty(x => x.ContactInfo, x =>
            {
                x.Property(x => x.PhoneNumber).HasMaxLength(100).HasColumnName("Phone");
                x.Property(x => x.Email).HasMaxLength(100).HasColumnName("Email");
                x.Property(x => x.WebSiteUrl).HasMaxLength(100).HasColumnName("WebSiteUrl");
            });

            builder.HasMany(r => r.Reviews)
                .WithOne()
                .HasForeignKey(r => r.CateringId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(w => w.WorkSchedules)
                .WithOne()
                .HasForeignKey(w => w.CateringId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Cuisines)
                .WithMany();

            builder.HasMany(x => x.Features)
                .WithMany();
        }
    }
}
