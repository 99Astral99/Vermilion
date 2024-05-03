using FluentResults;
using MediatR;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.Caterings.Commands.AddCuisine
{
    public sealed record AddCuisineCommand(CateringId CateringId, CuisineId CuisineId) : IRequest<Result>;
}
