using FluentResults;
using MediatR;
using System.ComponentModel.DataAnnotations;
using Vermilion.Contracts.Responses;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.Categories.Commands.UpdateCategory
{
    public sealed record UpdateCategoryCommand(CategoryId Id, [Required] string Name) 
        : IRequest<Result<ResponseCategory>>;
}
