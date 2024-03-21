using FluentResults;
using Vermilion.Domain.Common;
using Vermilion.Domain.ValueObjects;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Domain.Entities
{
    public class Restaurant : Entity<RestaurantId>
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public string Phone { get; private set; }
        public string? Email { get; private set; }
        public string? WebsiteUrl { get; private set; }

        public Address Address { get; private set; }

        public IReadOnlyList<Cuisine>? Cuisines => _cuisines.ToList();
        private readonly List<Cuisine> _cuisines = new();

        public IReadOnlyList<MenuItem>? Products => _products?.ToList();
        private readonly List<MenuItem> _products = new();

        public IReadOnlyList<Review>? Reviews => _reviews?.ToList();
        private readonly List<Review> _reviews = new();

        public IReadOnlyList<Menu>? Menus => _menus?.ToList();
        private readonly List<Menu> _menus = new();

        public IReadOnlyList<Feature>? Features => _features?.ToList();
        private readonly List<Feature> _features = new();

        public IReadOnlyList<WorkSchedule>? WorkSchedules => _workSchedules?.ToList();
        private readonly List<WorkSchedule> _workSchedules = new();


        private Restaurant(RestaurantId id, string name, string? description, string phone, string? email, string? websiteUrl, Address address) : base(id)
        {
            Name = name;
            Description = description ?? default;
            Phone = phone;
            Email = email ?? default;
            WebsiteUrl = websiteUrl ?? default;
            Address = address;
        }

        public static Result<Restaurant> Create(string name, string? description, string phone, string? email, string? websiteUrl, Address address)
        {
            var id = RestaurantId.CreateNew();
            var restaurant = new Restaurant(id, name, description, phone, email, websiteUrl, address);

            return Result.Ok(restaurant);
        }
    }
}
