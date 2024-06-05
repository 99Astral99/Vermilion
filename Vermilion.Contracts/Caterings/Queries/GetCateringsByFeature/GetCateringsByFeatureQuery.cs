using FluentResults;
using MediatR;
using Vermilion.Contracts.Responses.Caterings;

namespace Vermilion.Contracts.Caterings.Queries.GetCateringsByFeature
{
    public sealed record GetCateringsByFeatureQuery(string featureName) : IRequest<Result<IEnumerable<ResponseCatering>>>;

}
