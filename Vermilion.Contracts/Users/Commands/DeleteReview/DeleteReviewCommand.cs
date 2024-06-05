using FluentResults;
using MediatR;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.Users.Commands.DeleteReview
{
    public sealed record DeleteReviewCommand(ReviewId ReviewId) : IRequest<Result>;
}
