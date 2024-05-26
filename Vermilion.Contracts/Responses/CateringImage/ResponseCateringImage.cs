using Vermilion.Domain.ValueObjects;

namespace Vermilion.Contracts.Responses.CateringImage
{
    public sealed record ResponseCateringImage(CateringImageId Id, string Name, long Size, DateTime CreatedAt);
}
