using Vermilion.Domain.Entities;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.Responses.WorkSchedules
{
    public sealed record ResponseWorkSchedule(WorkSchedule Id, DayOfWeek DayOfWeek,
        TimeSpan StartTime, TimeSpan EndTime,
        bool IsDayOff,
        CateringId CateringId);
}