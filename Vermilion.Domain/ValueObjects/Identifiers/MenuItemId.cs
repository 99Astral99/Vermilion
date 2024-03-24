using Vermilion.Domain.Common;

namespace Vermilion.Domain.ValueObjects.Identifiers
{
    public record MenuItemId : EntityId
    {
        public MenuItemId(Guid value) : base(value)
        {
        }

        public static MenuItemId CreateNew()
        {
            return new MenuItemId(Guid.NewGuid());
        }
    }
}
