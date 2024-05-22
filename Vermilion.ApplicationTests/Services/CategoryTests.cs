using Vermilion.ApplicationTests.Common;

namespace Vermilion.ApplicationTests.Services
{
    public class CategoryTests : ClassFixture
    {
        public CategoryTests(ApplicationFixture applicationFixture) : base(applicationFixture)
        { }

        //#region Commands
        //[Theory]
        //[InlineData("name")]
        //public async void CmdCategoryCreate_Success(string name)
        //{
        //    var responseCategory = await Mediator.Send(new CreateCategoryCommand(name));
        //    name.Should().BeEquivalentTo(responseCategory.Value.Name);
        //}

        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData("name")]
        //public async void CmdCategoryUpdate_Success(string name)
        //{
        //    var createdCategory = await Mediator.Send(new CreateCategoryCommand(SomeString));
        //    var updatedCategory = await Mediator.Send(new UpdateCategoryCommand(createdCategory.Value.Id, name));
        //    name.Should().BeEquivalentTo(updatedCategory.Value.Name);
        //}

        //[Fact]
        //public async void CmdCategoryUpdate_HasNotFoundException()
        //{
        //    var notFoundException = await Mediator.Send(new UpdateCategoryCommand(new CategoryId(NotPossibleId), SomeString));
        //    notFoundException.HasException<NotFoundException>().Should().BeTrue();

        //}
        //[Fact]
        //public async void CmdCategoryDelete_Success()
        //{
        //    var createdCategoryResult = await Mediator.Send(new CreateCategoryCommand(SomeString));
        //    await Mediator.Send(new DeleteCategoryCommand(createdCategoryResult.Value.Id));
        //    var categoryResult = await Mediator.Send(new GetCategoryQuery(createdCategoryResult.Value.Id));

        //    categoryResult.HasException<NotFoundException>().Should().BeTrue();
        //}
        //#endregion

        //[Fact]
        //public async void CmdCategoryDelete_HasNotFoundException()
        //{
        //    var categoryResult = await Mediator.Send(new DeleteCategoryCommand(new CategoryId(NotPossibleId)));
        //    categoryResult.HasException<NotFoundException>().Should().BeTrue();
        //}

        //#region Queries
        //[Fact]
        //public async void QueryCategoryGetAll_Success()
        //{
        //    var createdCategoryResult = await Mediator.Send(new CreateCategoryCommand(SomeString));

        //    var categoriesResult = await Mediator.Send(new GetAllCategoriesQuery());

        //    categoriesResult.Value.Any(category => category.Id == createdCategoryResult.Value.Id).Should().BeTrue();
        //}

        //[Fact]
        //public async void QueryCategoryGet_Success()
        //{
        //    var createdCategory = await Mediator.Send(new CreateCategoryCommand(SomeString));
        //    var id = createdCategory.Value.Id;

        //    var responseCategory = await Mediator.Send(new GetCategoryQuery(id));

        //    responseCategory.Value.Id.Should().BeEquivalentTo(id);
        //}

        //[Theory]
        //[InlineData("D17B3AA9-C663-4722-BE2A-2562F001C696")]
        //public async void QueryCategoryGet_NotFoundException(string id)
        //{
        //    var notExistCategory = await Mediator.Send(new GetCategoryQuery(new CategoryId(new Guid(id))));
        //    notExistCategory.HasException<NotFoundException>().Should().BeTrue();
        //}
        //#endregion
    }
}
