using FluentResults;
using MediatR;
using Vermilion.Contracts.Responses.Caterings;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.Caterings.Queries.GetCateringDetails
{
    public sealed record GetCateringDetailsQuery
        (CateringId Id) : IRequest<Result<ResponseCateringInfo>>;
}
