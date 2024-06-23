using FluentResults;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Vermilion.Contracts.Users.Commands.LoginUser
{
    public sealed record LoginUserCommand(
             [Required] string Email, [Required] string Password) : IRequest<Result<string>>;
}
