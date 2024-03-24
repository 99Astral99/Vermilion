using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vermilion.Domain.Entities;
using Vermilion.Domain.ValueObjects.Identifiers;
using Vermilion.Infrastructure.Converters;

namespace Vermilion.Infrastructure.Configurations
{
    public class WorkScheduleConfiguration : IEntityTypeConfiguration<WorkSchedule>
    {
        public void Configure(EntityTypeBuilder<WorkSchedule> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasConversion(
                workScheduleId => workScheduleId.Value,
                value => new WorkScheduleId(value));

            builder.Property(p => p.DayOfWeek)
                .HasConversion<DayOfWeekConverter>()
                .IsRequired();

            builder.Property(p => p.StartTime).IsRequired();
            builder.Property(p => p.EndTime).IsRequired();

        }
    }
}
