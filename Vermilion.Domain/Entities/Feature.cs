using FluentResults;
using Vermilion.Domain.Common;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Domain.Entities
{
    public class Feature : Entity<FeatureId>
    {
        private Feature(FeatureId id, string name) : base(id)
        {
            Name = name;
        }

        private Feature() { }

        public string Name { get; private set; }

        public static Result<Feature> Create(string Name)
        {
            var id = new FeatureId(Guid.NewGuid());
            var feature = new Feature(id, Name);

            return Result.Ok(feature);
        }
    }
}