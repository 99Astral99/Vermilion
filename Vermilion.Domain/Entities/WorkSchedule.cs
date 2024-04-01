using FluentResults;
using Vermilion.Domain.Common;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Domain.Entities
{
    public class WorkSchedule : Entity<WorkScheduleId>
    {
        private WorkSchedule(WorkScheduleId id, DayOfWeek dayOfWeek, TimeSpan startTime, TimeSpan endTime, bool isDayOff, RestaurantId restaurantId) : base(id)
        {
            DayOfWeek = dayOfWeek;
            StartTime = startTime;
            EndTime = endTime;
            IsDayOff = isDayOff;
            RestaurantId = restaurantId;
        }

        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsDayOff { get; set; }
        public RestaurantId RestaurantId { get; private set; }

        public static Result<WorkSchedule> Create(DayOfWeek dayOfWeek, TimeSpan startTime, TimeSpan endTime, bool isDayOff, RestaurantId restaurantId)
        {
            var id = new WorkScheduleId(Guid.NewGuid());
            var workSchedule = new WorkSchedule(id, dayOfWeek, startTime, endTime, isDayOff, restaurantId);
            return Result.Ok(workSchedule);
        }
    }
}