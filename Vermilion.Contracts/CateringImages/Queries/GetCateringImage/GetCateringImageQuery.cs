using FluentResults;
using MediatR;
using Vermilion.Contracts.Responses.CateringImage;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.CateringImages.Queries.GetCateringImage
{
    public sealed record GetCateringImageQuery(CateringImageId Id) : IRequest<Result<ResponseCateringImage>>;
}
