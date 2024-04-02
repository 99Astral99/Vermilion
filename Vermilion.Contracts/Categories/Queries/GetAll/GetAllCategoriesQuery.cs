using FluentResults;
using MediatR;
using Vermilion.Contracts.Responses;

namespace Vermilion.Contracts.Categories.Queries.GetAll
{
    public record GetAllCategoriesQuery : IRequest<Result<IEnumerable<ResponseCategory>>>;
}
