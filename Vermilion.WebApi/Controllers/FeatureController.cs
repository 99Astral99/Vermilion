using Microsoft.AspNetCore.Mvc;
using Vermilion.Contracts.Features.Commands.CreateFeature;
using Vermilion.Contracts.Responses.Features;

namespace Vermilion.WebApi.Controllers
{
    public class FeatureController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<ResponseFeature>> Create([FromBody] CreateFeatureCommand command, CancellationToken cancellationToken)
        {
            var feature = await Mediator.Send(command, cancellationToken);

            return Ok(feature.Value);
        }
    }
}
