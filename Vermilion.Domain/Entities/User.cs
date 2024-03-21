using FluentResults;
using Vermilion.Domain.Common;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Domain.Entities
{
    public class User : Entity<UserId>
    {
        private User(UserId id, string firstName, string lastName, string email, DateTime dateRegistered, string phone) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateRegistered = dateRegistered;
            Phone = phone;
        }

        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string Email { get; private set; }
        public string? Phone { get; private set; }
        //сделать datetime iauditable
        public DateTime DateRegistered { get; private set; }

        private readonly List<Review> _reviews = new();
        public IReadOnlyList<Review>? Reviews => _reviews?.ToList();

        public static Result<User> Create(string firstName, string lastName, string email, DateTime dateRegistered, string phone)
        {
            var id = UserId.CreateNew();
            var user = new User(id, firstName, lastName, email, dateRegistered, phone);

            return Result.Ok(user);
        }
    }
}
