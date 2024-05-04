using FluentResults;
using Vermilion.Domain.Common;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Domain.Entities
{
    public class WorkSchedule : Entity<WorkScheduleId>
    {
        private WorkSchedule(WorkScheduleId id, DayOfWeek dayOfWeek, TimeSpan startTime, TimeSpan endTime, bool isDayOff, CateringId cateringId) : base(id)
        {
            DayOfWeek = dayOfWeek;
            StartTime = startTime;
            EndTime = endTime;
            IsDayOff = isDayOff;
            CateringId = cateringId;
        }

        private WorkSchedule() { }

        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsDayOff { get; set; }
        public CateringId CateringId { get; private set; }

        public static Result<WorkSchedule> Create(DayOfWeek dayOfWeek, TimeSpan startTime, TimeSpan endTime, bool isDayOff, CateringId cateringId)
        {
            var id = new WorkScheduleId(Guid.NewGuid());
            var workSchedule = new WorkSchedule(id, dayOfWeek, startTime, endTime, isDayOff, cateringId);
            return Result.Ok(workSchedule);
        }
    }
}