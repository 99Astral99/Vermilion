using FluentResults;
using MediatR;
using Vermilion.Contracts.Responses.Caterings;
using Vermilion.Domain.ValueObjects;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.Caterings.Commands.UpdateCatering
{
    public sealed record UpdateCateringCommand
        (CateringId Id, string Name, string Description, ContactInfo ContactInfo, string Address)
        : IRequest<Result<ResponseCatering>>;
}
