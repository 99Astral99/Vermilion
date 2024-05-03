using FluentResults;
using MediatR;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.Caterings.Commands.DeleteCatering
{
    public sealed record DeleteCateringCommand(CateringId Id) : IRequest<Result>;
}
