using FluentResults;
using MediatR;
using Vermilion.Contracts.Responses.Reviews;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.Users.Commands.AddReview
{
    public sealed record AddReviewCommand(CateringId CateringId, UserId UserId,
        string UserName, string Comment, int Rating) : IRequest<Result<ResponseReview>>;
}
