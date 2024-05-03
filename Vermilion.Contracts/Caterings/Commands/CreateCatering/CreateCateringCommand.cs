using FluentResults;
using MediatR;
using System.ComponentModel.DataAnnotations;
using Vermilion.Contracts.Responses.Caterings;
using Vermilion.Domain.ValueObjects;

namespace Vermilion.Contracts.Caterings.Commands.CreateCatering
{
    public sealed record CreateCateringCommand
        ([Required] string Name, string? Description,
        [Required] string Address, ContactInfo ContactInfo)
        : IRequest<Result<ResponseCatering>>;
}
