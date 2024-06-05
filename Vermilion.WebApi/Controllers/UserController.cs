using Microsoft.AspNetCore.Mvc;
using Vermilion.Contracts.Responses.Users;
using Vermilion.Contracts.Users.Commands.AddReview;
using Vermilion.Contracts.Users.Commands.DeleteReview;
using Vermilion.Contracts.Users.Commands.LoginUser;
using Vermilion.Contracts.Users.Commands.RegisterUser;

namespace Vermilion.WebApi.Controllers
{
    /// <summary>
    /// Контроллер для работы с пользователями
    /// </summary>
    public class UserController : BaseController
    {
        /// <summary> Регистрация </summary>
        [HttpPost]
        public async Task<IResult> Register([FromBody] RegisterUserRequest request)
        {
            var command = new RegisterUserCommand(request.FirstName, request.Email, request.Password);

            await Mediator.Send(command);

            return Results.Ok();
        }

        /// <summary> Логин </summary>
        [HttpPost]
        public async Task<IResult> Login([FromBody] LoginUserRequest request)
        {
            var command = new LoginUserCommand(request.Email, request.Password);

            var token = await Mediator.Send(command);

            HttpContext.Response.Cookies.Append("secretCookie", token.Value);

            return Results.Ok();
        }

        /// <summary> Добавить отзыв </summary>
        [HttpPost]
        public async Task<ActionResult> AddReview(AddReviewCommand command)
        {
            var res = await Mediator.Send(command);

            return Created(nameof(AddReview), res.Value);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteReview(DeleteReviewCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
