using FluentResults;
using Vermilion.Domain.Common;
using Vermilion.Domain.Interfaces;
using Vermilion.Domain.ValueObjects;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Domain.Entities
{
    public class Restaurant : Entity<RestaurantId>, IAuditable
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public string Phone { get; private set; }
        public string? Email { get; private set; }
        public string? WebsiteUrl { get; private set; }

        public Address Address { get; private set; }

        private Restaurant(RestaurantId id, string name, string? description, string phone, string? email, string? websiteUrl, Address address) : base(id)
        {
            Name = name;
            Description = description ?? default;
            Phone = phone;
            Email = email ?? default;
            WebsiteUrl = websiteUrl ?? default;
            Address = address;
        }

        private Restaurant() { }

        public IReadOnlyList<Cuisine>? Cuisines => _cuisines.ToList();
        private readonly List<Cuisine> _cuisines = new();

        public IReadOnlyList<MenuItem>? MenuItems => _menuItems?.ToList();
        private readonly List<MenuItem> _menuItems = new();

        public IReadOnlyList<Review>? Reviews => _reviews?.ToList();
        private readonly List<Review> _reviews = new();

        public IReadOnlyList<Menu>? Menus => _menus?.ToList();
        private readonly List<Menu> _menus = new();

        public IReadOnlyList<Feature>? Features => _features?.ToList();
        private readonly List<Feature> _features = new();

        public IReadOnlyList<WorkSchedule>? WorkSchedules => _workSchedules?.ToList();
        private readonly List<WorkSchedule> _workSchedules = new();

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public static Result<Restaurant> Create(string name, string? description, string phone, string? email, string? websiteUrl, Address address)
        {
            var id = new RestaurantId(Guid.NewGuid());
            var restaurant = new Restaurant(id, name, description, phone, email, websiteUrl, address);

            return Result.Ok(restaurant);
        }
    }
}
