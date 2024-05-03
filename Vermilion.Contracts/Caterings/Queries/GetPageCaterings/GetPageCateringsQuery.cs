using FluentResults;
using MediatR;
using Vermilion.Contracts.Responses.Caterings;

namespace Vermilion.Contracts.Caterings.Queries.GetPageCaterings
{
    public sealed record GetPageCateringsQuery(int pageNumber) 
        : IRequest<Result<IEnumerable<ResponseCatering>>>;
}
