using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.Responses.CateringImage
{
    public sealed record ResponseCateringImage(CateringImageId Id, string Name, long Size, DateTime CreatedAt);
}
