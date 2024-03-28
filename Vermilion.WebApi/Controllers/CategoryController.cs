using Microsoft.AspNetCore.Mvc;
using Vermilion.Contracts.Categories.Commands.CreateCategory;
using Vermilion.Contracts.Categories.Commands.DeleteCategory;
using Vermilion.Contracts.Categories.Commands.UpdateCategory;
using Vermilion.Contracts.Categories.Queries.GetAll;
using Vermilion.Contracts.Categories.Queries.GetCategory;
using Vermilion.Contracts.Responses;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.WebApi.Controllers
{
    public class CategoryController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ResponseCategory>> GetCategory([FromQuery]CategoryId Id, CancellationToken cancellationToken = default)
        {
            var category = await Mediator.Send(new GetCategoryQuery(Id), cancellationToken);

            return Ok(category);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = new GetAllCategoriesQuery();
            var categories = await Mediator.Send(query);

            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCategoryCommand command, CancellationToken cancellationToken = default)
        {
            var category = await Mediator.Send(command, cancellationToken);

            return Created(nameof(Create), category);
        }

        [HttpPost]
        public async Task<ActionResult> Update(UpdateCategoryCommand command, CancellationToken cancellation = default)
        {
            var updatedCategory = await Mediator.Send(command, cancellation);
            return Ok(updatedCategory);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
