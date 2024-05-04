using FluentResults;
using Vermilion.Domain.Common;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Domain.Entities
{
    public class Cuisine : Entity<CuisineId>
    {
        public string Name { get; private set; }

        private Cuisine(CuisineId id, string name) : base(id)
        {
            Name = name;
        }

        private Cuisine() { }

        public static Result<Cuisine> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Fail("Name can't be empty");

            var id = new CuisineId(Guid.NewGuid());
            var category = new Cuisine(id, name);

            return category;
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrEmpty(newName))
                throw new ArgumentNullException(nameof(newName));

            Name = newName;
        }
    }
}
