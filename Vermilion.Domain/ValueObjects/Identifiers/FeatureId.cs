using Vermilion.Domain.Common;

namespace Vermilion.Domain.ValueObjects.Identifiers
{
    public record FeatureId : EntityId
    {
        public FeatureId(Guid value) : base(value)
        {
        }

        public static FeatureId CreateNew()
        {
            return new FeatureId(Guid.NewGuid());
        }
    }
}