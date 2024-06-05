using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vermilion.Contracts.Caterings.Commands.AddCuisine;
using Vermilion.Contracts.Caterings.Commands.AddFeature;
using Vermilion.Contracts.Caterings.Commands.CreateCatering;
using Vermilion.Contracts.Caterings.Commands.DeleteCatering;
using Vermilion.Contracts.Caterings.Commands.UpdateCatering;
using Vermilion.Contracts.Caterings.Queries.GetAll;
using Vermilion.Contracts.Caterings.Queries.GetCateringDetails;
using Vermilion.Contracts.Caterings.Queries.GetCateringsByCuisine;
using Vermilion.Contracts.Caterings.Queries.GetCateringsByFeature;
using Vermilion.Contracts.Caterings.Queries.GetPageCaterings;
using Vermilion.Contracts.Caterings.Queries.GetPendingCaterings;
using Vermilion.Contracts.Responses.Caterings;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.WebApi.Controllers
{
    /// <summary>
    /// Контроллер для работы с ресторанами
    /// </summary>
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseCatering>>> GetPendingCaterings(CancellationToken cancellationToken = default)
        {
            return Ok((await Mediator.Send(new GetPendingCateringsQuery(), cancellationToken)).Value);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseCatering>>> GetCateringsByFeature(string featureName)
        {
            return Ok((await Mediator.Send(new GetCateringsByFeatureQuery(featureName))).Value);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseCatering>>> GetCateringsByCuisine(string cuisineName)
        {
            return Ok((await Mediator.Send(new GetCateringsByCuisineQuery(cuisineName))).Value);
        }

        /// <summary> Метод для создания общепита </summary>
        [Authorize(Roles = "User, Admin")]
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

        [HttpDelete]
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
