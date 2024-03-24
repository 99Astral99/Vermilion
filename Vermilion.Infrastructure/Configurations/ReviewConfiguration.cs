using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vermilion.Domain.Entities;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Infrastructure.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasConversion(
                reviewId => reviewId.ToString(),
                value => new ReviewId(value));

            builder.Property(p => p.Comment).HasMaxLength(500).IsRequired();
            builder.Property(r => r.Rating).IsRequired();
        }
    }
}
