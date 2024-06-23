using FluentResults;
using Vermilion.Domain.Common;
using Vermilion.Domain.DomainEvents;
using Vermilion.Domain.Interfaces;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Domain.Entities
{
    public class Review : Entity<ReviewId>, IAuditable
    {
        public CateringId CateringId { get; private set; }
        public UserId UserId { get; private set; }
        public string? UserName { get; private set; }
        public string Comment { get; private set; }
        public int Rating { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public const int MIN_RATING_VALUE = 1;
        public const int MAX_RATING_VALUE = 5;

        private Review(ReviewId id, CateringId cateringId, UserId userId, string userName, string comment, int rating) : base(id)
        {
            CateringId = cateringId;
            UserId = userId;
            Comment = comment;
            Rating = rating;
            UserName = userName;
        }

        private Review() { }

        public static Result<Review> Create(CateringId cateringId, UserId userId, string userName, string comment, int rating)
        {
            if (string.IsNullOrWhiteSpace(comment))
                return Result.Fail("Comment can't be null");

            if (rating < MIN_RATING_VALUE || rating > MAX_RATING_VALUE)
                return Result.Fail($"Rating value must be between {MIN_RATING_VALUE} and {MAX_RATING_VALUE}");

            var id = new ReviewId(Guid.NewGuid());
            var review = new Review(id, cateringId, userId, userName, comment, rating);

            review.Raise(new ReviewCreatedDomainEvent(Guid.NewGuid(), review.Id, cateringId, userName, rating));

            return Result.Ok(review);
        }

        public void UpdateComment(string newComment)
        {
            Comment = newComment;
        }

        public void UpdateRating(int rating)
        {
            Rating = rating;
        }
    }
}