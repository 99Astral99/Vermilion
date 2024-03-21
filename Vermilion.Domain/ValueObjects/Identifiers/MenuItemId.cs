namespace Vermilion.Domain.ValueObjects.Identifiers
{
    public record MenuItemId : EntityId
    {
        public MenuItemId(string value) : base(value)
        {
        }

        public static MenuItemId CreateNew()
        {
            return new MenuItemId(Guid.NewGuid().ToString());
        }
    }
}
