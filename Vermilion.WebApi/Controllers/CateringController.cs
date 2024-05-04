using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Vermilion.Contracts.Caterings.Commands.AddCuisine;
using Vermilion.Contracts.Caterings.Commands.AddFeature;
using Vermilion.Contracts.Caterings.Commands.CreateCatering;
using Vermilion.Contracts.Caterings.Commands.DeleteCatering;
using Vermilion.Contracts.Caterings.Commands.UpdateCateringCommand;
using Vermilion.Contracts.Caterings.Queries.GetAll;
using Vermilion.Contracts.Caterings.Queries.GetCateringDetails;
using Vermilion.Contracts.Caterings.Queries.GetPageCaterings;
using Vermilion.Contracts.Responses.Caterings;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.WebApi.Controllers
{
    public class CateringController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ResponseCateringInfo>> GetDetails([FromQuery] CateringId id, CancellationToken cancellationToken = default)
        {
            var catering = await Mediator.Send(new GetCateringDetailsQuery(id), cancellationToken);
            return Ok(catering.Value);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseCatering>>> GetCaterings(CancellationToken cancellationToken = default)
        {
            return Ok((await Mediator.Send(new GetAllCateringQuery(), cancellationToken)).Value);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseCatering>>> GetCateringsPage(int pageNumber, CancellationToken cancellationToken = default)
        {
            var res = await Mediator.Send(new GetPageCateringsQuery(pageNumber), cancellationToken);
            return Ok(res.Value);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseCatering>> Create([FromBody] CreateCateringCommand command, CancellationToken cancellationToken = default)
        {
            var catering = await Mediator.Send(command, cancellationToken);

            return Created(nameof(Create), catering.Value);
        }

        [HttpPost]
        public async Task<ActionResult<Result>> Update([FromBody] UpdateCateringCommand command)
        {
            var updatedCatering = await Mediator.Send(command);
            return Ok(updatedCatering.Value);
        }

        [HttpPost]
        public async Task<ActionResult<Result>> Delete([FromBody] DeleteCateringCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<Result>> AddCuisine([FromBody] AddCuisineCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> AddFeature([FromBody] AddFeatureCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
