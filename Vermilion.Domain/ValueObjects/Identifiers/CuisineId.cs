using Vermilion.Domain.Common;

namespace Vermilion.Domain.ValueObjects.Identifiers
{
    public record CuisineId : EntityId
    {
        public CuisineId(Guid value) : base(value)
        {
        }

        public static CuisineId CreateNew()
        {
            return new CuisineId(Guid.NewGuid());
        }
    }
}