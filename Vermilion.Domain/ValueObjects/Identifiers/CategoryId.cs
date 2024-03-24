using Vermilion.Domain.Common;

namespace Vermilion.Domain.ValueObjects.Identifiers
{
    public record CategoryId : EntityId
    {
        public CategoryId(Guid value) : base(value)
        {
        }

        public static CategoryId CreateNew()
        {
            return new CategoryId(Guid.NewGuid());
        }
    }
}