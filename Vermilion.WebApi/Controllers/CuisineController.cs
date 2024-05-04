using Microsoft.AspNetCore.Mvc;
using Vermilion.Contracts.Cuisines.Commands;
using Vermilion.Contracts.Responses.Cuisines;

namespace Vermilion.WebApi.Controllers
{
    public class CuisineController : BaseController
    {
        //[HttpGet]
        //public async Task<ActionResult<ResponseCuisine>> Get([FromQuery] CuisineId Id, CancellationToken cancellationToken)
        //{
        //    //var cuisine = await Mediator.Send(new GetCuisineQuery(Id), cancellationToken);
        //    //return Ok(cuisine.Value);
        //}
        [HttpPost]
        public async Task<ActionResult<ResponseCuisine>> Create([FromBody] CreateCuisineCommand command, CancellationToken cancellationToken)
        {
            var createdCuisine = await Mediator.Send(command, cancellationToken);

            return Ok(createdCuisine.Value);
        }

    }
}
