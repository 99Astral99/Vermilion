using Vermilion.Domain.Common;

namespace Vermilion.Domain.ValueObjects.Identifiers
{
    public record MenuId : EntityId
    {
        public MenuId(Guid value) : base(value)
        {
        }
        public static MenuId CreateNew()
        {
            return new MenuId(Guid.NewGuid());
        }
    }
}
