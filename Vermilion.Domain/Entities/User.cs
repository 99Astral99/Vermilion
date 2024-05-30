using FluentResults;
using System.Text.Json.Serialization;
using Vermilion.Domain.Common;
using Vermilion.Domain.Enums;
using Vermilion.Domain.Interfaces;
using Vermilion.Domain.ValueObjects;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Domain.Entities
{
    public class User : Entity<UserId>, IAuditable
    {
        [JsonConstructor]
        private User(UserId id, FullName fullName, string email, string? phone, string passwordHash) : base(id)
        {
            FullName = fullName;
            Email = email;
            Phone = phone ?? string.Empty;
            PasswordHash = passwordHash;
        }

        private User() { }

        public FullName FullName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string PasswordHash { get; private set; } = string.Empty;
        public UserRole Role { get; private set; } = UserRole.User;
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private readonly List<Review> _reviews = new();
        public IReadOnlyList<Review>? Reviews => _reviews?.ToList();

        public static Result<User> Create(FullName fullName, string Email, string? Phone, string passwordHash)
        {
            var id = new UserId(Guid.NewGuid());
            var user = new User(id, fullName, Email, Phone, passwordHash);

            return Result.Ok(user);
        }

        public void AddReview(Review review)
        {
            // TO DO Validation
            _reviews.Add(review);
        }
    }
}
