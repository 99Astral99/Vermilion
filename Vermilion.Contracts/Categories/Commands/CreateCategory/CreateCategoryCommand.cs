using FluentResults;
using MediatR;
using System.ComponentModel.DataAnnotations;
using Vermilion.Contracts.Responses;

namespace Vermilion.Contracts.Categories.Commands.CreateCategory
{
    public sealed record CreateCategoryCommand(
        [Required] string Name) : IRequest<Result<ResponseCategory>>;
}
