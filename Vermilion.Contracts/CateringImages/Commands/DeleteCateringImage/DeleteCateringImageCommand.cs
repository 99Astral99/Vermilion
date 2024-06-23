using FluentResults;
using MediatR;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.CateringImages.Commands.DeleteCateringImage
{
    public sealed record DeleteCateringImageCommand(CateringId cateringId, string fileName) : IRequest<Result>;
}
