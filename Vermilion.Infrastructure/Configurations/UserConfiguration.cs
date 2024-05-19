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
                userId => userId.Value,
                value => new UserId(value));

            builder.HasIndex(e => e.Email).IsUnique();
            builder.Property(p => p.Email).IsRequired();

            builder.HasIndex(p => p.Phone).IsUnique();
            builder.Property(p => p.Phone).IsRequired();

            builder.ComplexProperty(x => x.FullName, x =>
            {
                x.Property(x => x.FirstName).HasColumnName("FirstName");
                x.Property(x => x.LastName).HasColumnName("LastName");
                x.Property(x => x.MiddleName).HasColumnName("MiddleName");
            });

            builder.HasMany(r => r.Reviews)
                .WithOne()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
