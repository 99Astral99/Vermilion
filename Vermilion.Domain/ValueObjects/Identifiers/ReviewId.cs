using Vermilion.Domain.Common;

namespace Vermilion.Domain.ValueObjects.Identifiers
{
    public record ReviewId : EntityId
    {
        public ReviewId(Guid value) : base(value)
        {
        }

        public static ReviewId CreateNew()
        {
            return new ReviewId(Guid.NewGuid());
        }
    }
}