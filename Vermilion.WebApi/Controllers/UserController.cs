using Microsoft.AspNetCore.Mvc;
using Vermilion.Contracts.Users.Commands.AddReview;

namespace Vermilion.WebApi.Controllers
{
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> AddReview(AddReviewCommand command)
        {
            var res = await Mediator.Send(command);

            return Created(nameof(AddReview), res.Value);
        }
    }
}
