using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vermilion.Domain.Entities;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Infrastructure.Configurations
{
    public class CuisineConfiguration : IEntityTypeConfiguration<Cuisine>
    {
        public void Configure(EntityTypeBuilder<Cuisine> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(x => x.Id).HasConversion(
                cuisineId => cuisineId.Value,
                value => new CuisineId(value));

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasData(Cuisine.Create("Type1").Value);
        }
    }
}
