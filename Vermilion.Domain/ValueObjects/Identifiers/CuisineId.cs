namespace Vermilion.Domain.ValueObjects.Identifiers
{
    public record CuisineId : EntityId
    {
        public CuisineId(string value) : base(value)
        {
        }

        public static CuisineId CreateNew()
        {
            return new CuisineId(Guid.NewGuid().ToString());
        }
    }
}