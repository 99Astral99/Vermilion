using FluentResults;
using MediatR;
using Vermilion.Contracts.Responses.Caterings;

namespace Vermilion.Contracts.Caterings.Queries.GetCateringsByCuisine
{
    public sealed record GetCateringsByCuisineQuery(string cuisineName) : IRequest<Result<IEnumerable<ResponseCatering>>>;
}
