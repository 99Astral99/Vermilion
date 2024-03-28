using MediatR;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.Categories.Commands.DeleteCategory
{
    public record DeleteCategoryCommand(CategoryId Id) : IRequest;
}
