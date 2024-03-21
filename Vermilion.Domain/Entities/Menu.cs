using FluentResults;
using Vermilion.Domain.Common;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Domain.Entities
{
    public class Menu : Entity<MenuId>
    {
        private Menu(MenuId id, string name, RestaurantId restaurantId) : base(id)
        {
            Name = name;
            RestaurantId = restaurantId;
        }

        public string Name { get; private set; }

        public RestaurantId RestaurantId { get; private set; }
        private readonly List<MenuItem> _menuItems = new();
        public IReadOnlyList<MenuItem>? MenuItems => _menuItems?.ToList();

        public static Result<Menu> Create(string name, RestaurantId restaurantId)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Fail("Name can't be empty");

            var id = MenuId.CreateNew();
            var menu = new Menu(id, name, restaurantId);

            return Result.Ok(menu);
        }
    }
}
