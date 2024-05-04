using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.Responses.Features
{
    public sealed record ResponseFeature(FeatureId Id, string Name);
}
