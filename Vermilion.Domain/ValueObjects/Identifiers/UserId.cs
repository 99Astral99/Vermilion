using Vermilion.Domain.Common;

namespace Vermilion.Domain.ValueObjects.Identifiers
{
    public record UserId : EntityId
    {
        public UserId(Guid value) : base(value)
        {
        }

        public static UserId CreateNew()
        {
            return new UserId(Guid.NewGuid());
        }
    }
}
