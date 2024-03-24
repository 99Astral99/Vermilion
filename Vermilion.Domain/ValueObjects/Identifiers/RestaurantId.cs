using Vermilion.Domain.Common;

namespace Vermilion.Domain.ValueObjects.Identifiers
{
    public sealed record RestaurantId : EntityId
    {
        public RestaurantId(string value) : base(value)
        {
        }

        public static RestaurantId CreateNew()
        {
            return new RestaurantId(Guid.NewGuid().ToString());
        }
    }
}
