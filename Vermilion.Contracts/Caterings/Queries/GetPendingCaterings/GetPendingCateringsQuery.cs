using FluentResults;
using MediatR;
using Vermilion.Contracts.Responses.Caterings;

namespace Vermilion.Contracts.Caterings.Queries.GetPendingCaterings
{
    public sealed record GetPendingCateringsQuery :
        IRequest<Result<IEnumerable<ResponseCatering>>>;
}
