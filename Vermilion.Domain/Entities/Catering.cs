using FluentResults;
using System.Text.Json.Serialization;
using Vermilion.Domain.Common;
using Vermilion.Domain.Interfaces;
using Vermilion.Domain.ValueObjects;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Domain.Entities
{
    public class Catering : Entity<CateringId>, IAuditable, IAggregateRoot
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public ContactInfo ContactInfo { get; private set; }
        public string Address { get; private set; }
        public double AverageRating { get; private set; } = 0;


        [JsonConstructor]
        private Catering(CateringId id, string name, string? description, ContactInfo contactInfo, string address) : base(id)
        {
            Name = name;
            Description = description ?? default;
            Address = address;
            ContactInfo = contactInfo;
        }

        private Catering() { }

        public IReadOnlyList<Cuisine>? Cuisines => _cuisines?.ToList();
        private readonly List<Cuisine> _cuisines = new();

        public IReadOnlyList<Review>? Reviews => _reviews?.ToList();
        private readonly List<Review> _reviews = new();

        public IReadOnlyList<Feature>? Features => _features?.ToList();
        private readonly List<Feature> _features = new();

        public IReadOnlyList<WorkSchedule>? WorkSchedules => _workSchedules?.ToList();
        private readonly List<WorkSchedule> _workSchedules = new();

        public IReadOnlyList<CateringImage>? CateringImage => _cateringImages?.ToList();
        private readonly List<CateringImage> _cateringImages = new();

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public static Result<Catering> Create(string name, string? description, ContactInfo contactInfo, string address)
        {
            var id = new CateringId(Guid.NewGuid());
            var catering = new Catering(id, name, description, contactInfo, address);

            return Result.Ok(catering);
        }

        public void UpdateDetails(ContactInfo contactInfo, string? name = null, string? description = null, string? address = null)
        {
            Name = name ?? Name;
            Description = description ?? Description;
            ContactInfo = contactInfo ?? ContactInfo;
            Address = address ?? Address;
        }

        public void UpdateAverageRating(double value)
        {
            AverageRating = value;
        }
        public void AddFeature(Feature feature) => _features.Add(feature);

        public void RemoveFeature(string featureName)
        {
            if (string.IsNullOrEmpty(featureName))
                return;

            var feature = _features.Find(x => x.Name == featureName);
            _features.Remove(feature);
        }

        public void AddCuisine(Cuisine cuisine) => _cuisines.Add(cuisine);

        public void RemoveCuisine(string cuisineName)
        {
            if (string.IsNullOrEmpty(cuisineName))
                return;
            var cuisine = _cuisines.Find(x => x.Name == cuisineName);
            _cuisines.Remove(cuisine);
        }
    }
}
