using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vermilion.Domain.Entities;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Infrastructure.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(
                menuId => menuId.ToString(),
                value => new MenuId(value));

            builder.HasMany(m => m.MenuItems)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(n => n.Name).HasMaxLength(100).IsRequired();
        }
    }
}
