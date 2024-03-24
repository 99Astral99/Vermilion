using FluentResults;
using Vermilion.Domain.Common;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Domain.Entities
{
    public class Category : Entity<CategoryId>
    {
        private Category(CategoryId id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public static Result<Category> Create(string name)
        {
            var id = CategoryId.CreateNew();
            var category = new Category(id, name);

            return Result.Ok(category);
        }
    }
}
