using FluentResults;
using MediatR;
using System.ComponentModel.DataAnnotations;
using Vermilion.Contracts.Responses.Features;

namespace Vermilion.Contracts.Features.Commands.CreateFeature
{
    public sealed record CreateFeatureCommand
        ([Required] string Name) : IRequest<Result<ResponseFeature>>;
}
