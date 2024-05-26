using Microsoft.AspNetCore.Mvc;
using Vermilion.Contracts.CateringImages.Commands.DeleteCateringImage;
using Vermilion.Contracts.CateringImages.Commands.UploadCateringImage;
using Vermilion.Contracts.CateringImages.Queries.GetCateringImage;
using Vermilion.Domain.ValueObjects;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.WebApi.Controllers
{
    public class CateringImageController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetImage([FromQuery]CateringImageId Id)
        {
            var res = await Mediator.Send(new GetCateringImageQuery(Id));

            return Ok(res.Value);
        }

        [HttpPost]
        public async Task<ActionResult> UploadImage(IFormFile formFile, [FromQuery] CateringId cateringId)
        {
            var res = await Mediator.Send(new UploadCateringImageCommand(formFile.OpenReadStream(), formFile.FileName, formFile.ContentType, cateringId));

            return Ok(res.Value);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteImage(DeleteCateringImageCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }
    }
}
