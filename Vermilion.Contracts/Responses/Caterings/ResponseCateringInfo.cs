using Vermilion.Contracts.Responses.Cuisines;
using Vermilion.Contracts.Responses.Features;
using Vermilion.Contracts.Responses.Reviews;
using Vermilion.Contracts.Responses.WorkSchedules;
using Vermilion.Domain.ValueObjects;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.Responses.Caterings
{
    public sealed record ResponseCateringInfo
        (CateringId Id,
        string Name, string? Description,
        string Address, double averageRating, ContactInfo ContactInfo,
        List<ResponseFeature> features,
        List<ResponseWorkSchedule> workSchedules,
        List<ResponseCuisine> cuisines,
        List<ResponseReview> reviews);
}