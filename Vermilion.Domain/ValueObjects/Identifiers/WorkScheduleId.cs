using Vermilion.Domain.Common;

namespace Vermilion.Domain.ValueObjects.Identifiers
{
    public record WorkScheduleId : EntityId
    {
        public WorkScheduleId(Guid value) : base(value)
        {
        }

        public static WorkScheduleId CreateNew()
        {
            return new WorkScheduleId(Guid.NewGuid());
        }
    }
}
