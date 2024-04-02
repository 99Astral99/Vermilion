using FluentResults;
using MediatR;
using Vermilion.Contracts.Responses;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.Categories.Queries.GetCategory
{
    public record GetCategoryQuery(CategoryId Id) : IRequest<Result<ResponseCategory>>;
}
