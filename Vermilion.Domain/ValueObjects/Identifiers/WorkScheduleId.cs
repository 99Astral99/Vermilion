namespace Vermilion.Domain.ValueObjects.Identifiers
{
    public record WorkScheduleId : EntityId
    {
        public WorkScheduleId(string value) : base(value)
        {
        }

        public static WorkScheduleId CreateNew()
        {
            return new WorkScheduleId(Guid.NewGuid().ToString());
        }
    }
}
