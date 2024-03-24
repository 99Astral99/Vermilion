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

        public static Feature Create(string Name)
        {
            var id = FeatureId.CreateNew();
            var feature = new Feature(id, Name);

            return feature;
        }
        public string Name { get; private set; }
    }
}