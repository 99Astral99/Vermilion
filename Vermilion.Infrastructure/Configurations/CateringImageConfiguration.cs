using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vermilion.Domain.Entities;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Infrastructure.Configurations
{
    public class CateringImageConfiguration : IEntityTypeConfiguration<CateringImage>
    {
        public void Configure(EntityTypeBuilder<CateringImage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(cateringImageId => cateringImageId.Value,
                value => new CateringImageId(value));

            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Size).IsRequired();
        }
    }
}
