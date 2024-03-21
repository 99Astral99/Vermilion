namespace Vermilion.Domain.ValueObjects.Identifiers
{
    public record UserId : EntityId
    {
        public UserId(string value) : base(value)
        {
        }

        public static UserId CreateNew()
        {
            return new UserId(Guid.NewGuid().ToString());
        }
    }
}
