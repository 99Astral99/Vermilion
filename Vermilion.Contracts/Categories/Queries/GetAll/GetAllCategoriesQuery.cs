using MediatR;
using Vermilion.Contracts.Responses;

namespace Vermilion.Contracts.Categories.Queries.GetAll
{
    public record GetAllCategoriesQuery : IRequest<IEnumerable<ResponseCategory>>;
}
