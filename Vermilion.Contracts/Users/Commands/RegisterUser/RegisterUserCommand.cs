using FluentResults;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Vermilion.Contracts.Users.Commands.RegisterUser
{
    public sealed record RegisterUserCommand([Required] string Name,
         [Required] string Email, [Required] string Password) : IRequest<Result>;
}
