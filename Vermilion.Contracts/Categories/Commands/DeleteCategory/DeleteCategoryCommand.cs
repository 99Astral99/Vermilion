using FluentResults;
using MediatR;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.Categories.Commands.DeleteCategory
{
    public sealed record DeleteCategoryCommand(CategoryId Id) : IRequest<Result>;
}
