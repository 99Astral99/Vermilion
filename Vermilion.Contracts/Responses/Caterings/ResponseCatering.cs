using Vermilion.Contracts.Responses.Cuisines;
using Vermilion.Contracts.Responses.Features;
using Vermilion.Domain.ValueObjects;

namespace Vermilion.Contracts.Responses.Caterings
{
    public sealed record ResponseCatering(
        string Name, string Description, double averageRating,
        string Address, ContactInfo ContactInfo,
        List<ResponseFeature> features,
        List<ResponseCuisine> cuisines);
}