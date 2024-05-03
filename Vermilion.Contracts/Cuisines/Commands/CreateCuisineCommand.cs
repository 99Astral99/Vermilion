using FluentResults;
using MediatR;
using System.ComponentModel.DataAnnotations;
using Vermilion.Contracts.Responses.Cuisines;

namespace Vermilion.Contracts.Cuisines.Commands
{
    public sealed record CreateCuisineCommand
        ([Required] string Name) : IRequest<Result<ResponseCuisine>>;
}
