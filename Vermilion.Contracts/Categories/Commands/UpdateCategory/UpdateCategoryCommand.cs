using MediatR;
using System.ComponentModel.DataAnnotations;
using Vermilion.Contracts.Responses;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.Categories.Commands.UpdateCategory
{
    public record UpdateCategoryCommand(CategoryId Id, [Required] string Name) : IRequest<ResponseCategory>;
}
