using FluentAssertions;
using Vermilion.Application.Common.Exceptions;
using Vermilion.ApplicationTests.Common;
using Vermilion.Contracts.Caterings.Commands.AddFeature;
using Vermilion.Contracts.Caterings.Commands.CreateCatering;
using Vermilion.Contracts.Caterings.Commands.DeleteCatering;
using Vermilion.Contracts.Caterings.Commands.UpdateCatering;
using Vermilion.Contracts.Caterings.Queries.GetAll;
using Vermilion.Contracts.Caterings.Queries.GetCateringDetails;
using Vermilion.Contracts.Caterings.Queries.GetCateringsByCuisine;
using Vermilion.Contracts.Caterings.Queries.GetCateringsByFeature;
using Vermilion.Contracts.Caterings.Queries.GetPendingCaterings;
using Vermilion.Contracts.Cuisines.Commands;
using Vermilion.Contracts.Features.Commands.CreateFeature;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.ApplicationTests.Services
{
    public class CateringTests : ClassFixture
    {
        public CateringTests(ApplicationFixture applicationFixture) : base(applicationFixture)
        {

        }

        #region Commands

        [Theory]
        [InlineData("name", "description", "address")]
        public async void CmdCateringCreate_Success(string name, string? description, string address)
        {

            var createCateringCommand = await Mediator.Send(new CreateCateringCommand(name, description, address));

            name.Should().BeEquivalentTo(createCateringCommand.Value.Name);
            description.Should().BeEquivalentTo(createCateringCommand.Value.Description);
            address.Should().BeEquivalentTo(createCateringCommand.Value.Address);
        }

        [Theory]
        [InlineData("name", "description", "address")]
        public async void CmdCateringUpdate_Success(string name, string description, string address)
        {
            var createdCatering = await Mediator.Send(new CreateCateringCommand(name, description, address));

            var updatedString = await Mediator.Send(new UpdateCateringCommand(createdCatering.Value.Id, name, description, address));

            name.Should().BeEquivalentTo(updatedString.Value.Name);
            description.Should().BeEquivalentTo(updatedString.Value.Description);
            address.Should().BeEquivalentTo(updatedString.Value.Address);
        }

        [Fact]
        public async void CmdCategoryDelete_Success()
        {
            var createdCateringResult = await Mediator.Send(new CreateCateringCommand(SomeString, SomeString, SomeString));
            await Mediator.Send(new DeleteCateringCommand(createdCateringResult.Value.Id));
            var cateringResult = await Mediator.Send(new GetCateringDetailsQuery(createdCateringResult.Value.Id));

            cateringResult.HasException<NotFoundException>().Should().BeTrue();
        }

        [Fact]
        public async void CmdCateringDelete_Catering_NotFound()
        {
            var cateringResult = await Mediator.Send(new DeleteCateringCommand(new CateringId(NotPossibleId)));
            cateringResult.HasException<NotFoundException>().Should().BeTrue();
        }

        [Fact]
        public async void CmdCateringUpdate_Catering_NotFound_()
        {
            var cateringResult = await Mediator.Send(new UpdateCateringCommand(new CateringId(NotPossibleId), SomeString, SomeString, SomeString));
            cateringResult.HasException<NotFoundException>().Should().BeTrue();
        }

        [Fact]
        public async void CmdAssignmentDelete_Assignment_NotFound()
        {
            var cateringResult = await Mediator.Send(new DeleteCateringCommand(new CateringId(NotPossibleId)));
            cateringResult.HasException<NotFoundException>().Should().BeTrue();
        }

        #endregion

        #region Queries
        [Fact]
        public async void QueryCateringGetDetails_Success()
        {
            var cateringResult = await Mediator.Send(new CreateCateringCommand(SomeString, SomeString, SomeString));
            var id = cateringResult.Value.Id;

            var cateringGetResult = await Mediator.Send(new GetCateringDetailsQuery(id));

            id.Should().BeEquivalentTo(cateringGetResult.Value.Id);
        }

        [Fact]
        public async void QueryCateringGetDetails_NotFound()
        {
            var cateringResult = await Mediator.Send(new GetCateringDetailsQuery(new CateringId(new Guid(SomeString))));

            cateringResult.HasException<NotFoundException>().Should().BeTrue();
        }

        [Fact]
        public async void QueryCateringsByCuisine_Success()
        {
            await Mediator.Send(new CreateCuisineCommand("Japan"));
            var responseCaterings = await Mediator.Send(new GetCateringsByCuisineQuery("Japan"));
            Assert.True(responseCaterings.Value.All(catering => catering.cuisines.Any(cuisine => cuisine.Name == "Japan")));
        }

        [Fact]
        public async void QueryCateringsByFeature_Success()
        {
            var feature = await Mediator.Send(new CreateFeatureCommand("Wi-fi"));

            var catering = await Mediator.Send(new CreateCateringCommand(SomeString, SomeString, SomeString));
            await Mediator.Send(new AddFeatureCommand(catering.Value.Id, feature.Value.Id));

            var responseCaterings = await Mediator.Send(new GetCateringsByFeatureQuery("Wi-fi"));
            Assert.True(responseCaterings.Value.All(catering => catering.features.Any(feature => feature.Name == "Wi-fi")));
        }

        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        public async void QueryCatering_GetPendingCaterings_Success(int count)
        {
            for (var i = 0; i < count; i++)
            {
                await Mediator.Send(new CreateCateringCommand($"Name{i}", SomeString, $"Address{i}"));
            }

            var cateringsGetPending = await Mediator.Send(new GetPendingCateringsQuery());

            count.Should().Be(cateringsGetPending.Value.Count());
        }


        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        public async void QueryCateringGetAllCaterings_Success(int count)
        {
            for (var i = 0; i < count; i++)
            {
                await Mediator.Send(new CreateCateringCommand($"Name{i}", SomeString, $"Address{i}"));
            }

            var cateringsGetAll = await Mediator.Send(new GetAllCateringQuery());

            count.Should().Be(cateringsGetAll.Value.Count());
        }
        #endregion
    }
}
