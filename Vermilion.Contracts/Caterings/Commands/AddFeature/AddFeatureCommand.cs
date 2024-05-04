using FluentResults;
using MediatR;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.Caterings.Commands.AddFeature
{
    public sealed record AddFeatureCommand(CateringId CateringId, FeatureId FeatureId) : IRequest<Result>;
}
