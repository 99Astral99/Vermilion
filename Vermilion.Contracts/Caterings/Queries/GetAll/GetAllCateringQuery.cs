using FluentResults;
using MediatR;
using Vermilion.Contracts.Responses.Caterings;

namespace Vermilion.Contracts.Caterings.Queries.GetAll
{
    public sealed record GetAllCateringQuery :
        IRequest<Result<IEnumerable<ResponseCatering>>>;
}
