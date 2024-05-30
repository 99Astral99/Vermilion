using Microsoft.AspNetCore.Mvc;
using Vermilion.Contracts.Responses.Users;
using Vermilion.Contracts.Users.Commands.AddReview;
using Vermilion.Contracts.Users.Commands.LoginUser;
using Vermilion.Contracts.Users.Commands.RegisterUser;

namespace Vermilion.WebApi.Controllers
{
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<IResult> Register([FromBody] RegisterUserRequest request)
        {
            var command = new RegisterUserCommand(request.FirstName, request.Email, request.Password);

            await Mediator.Send(command);

            return Results.Ok();
        }

        [HttpPost]
        public async Task<IResult> Login([FromBody] LoginUserRequest request)
        {
            var command = new LoginUserCommand(request.Email, request.Password);

            var token = await Mediator.Send(command);

            HttpContext.Response.Cookies.Append("secretCookie", token.Value);

            return Results.Ok();
        }

        [HttpPost]
        public async Task<ActionResult> AddReview(AddReviewCommand command)
        {
            var res = await Mediator.Send(command);

            return Created(nameof(AddReview), res.Value);
        }
    }
}
