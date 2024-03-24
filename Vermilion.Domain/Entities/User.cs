using FluentResults;
using Vermilion.Domain.Common;
using Vermilion.Domain.Interfaces;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Domain.Entities
{
    public class User : Entity<UserId>, IAuditable
    {
        private User(UserId id, string firstName, string lastName, string email, string phone) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string Email { get; private set; }
        public string? Phone { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private readonly List<Review> _reviews = new();
        public IReadOnlyList<Review>? Reviews => _reviews?.ToList();

        public static Result<User> Create(string firstName, string lastName, string email, string phone)
        {
            var id = UserId.CreateNew();
            var user = new User(id, firstName, lastName, email, phone);

            return Result.Ok(user);
        }
    }
}
