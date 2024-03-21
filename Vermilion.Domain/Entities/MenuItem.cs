using FluentResults;
using Vermilion.Domain.Common;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Domain.Entities
{
    public class MenuItem : Entity<MenuItemId>
    {
        public CategoryId CategoryId { get; private set; }
        public MenuId MenuId { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }

        private MenuItem(MenuItemId id, CategoryId categoryId, MenuId menuId, string name, string description, decimal price) : base(id)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Price = price;
            MenuId = menuId;
        }

        public static Result<MenuItem> Create(CategoryId categoryId, MenuId menuId, string name, string description, decimal price)
        {
            var id = MenuItemId.CreateNew();
            var menuItem = new MenuItem(id, categoryId, menuId, name, description, price);

            return Result.Ok(menuItem);
        }
    }
}
