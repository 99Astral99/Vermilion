using MediatR;

namespace Vermilion.ApplicationTests.Common
{
    public abstract class ClassFixture : IClassFixture<ApplicationFixture>
    {
        protected readonly IMediator Mediator;
        protected readonly Guid NotPossibleId;
        protected readonly Guid UserId;
        protected readonly string SomeString;

        protected ClassFixture(ApplicationFixture applicationFixture)
        {
            Mediator = applicationFixture.Mediator;
            NotPossibleId = new Guid("3CF3217F-320D-422F-AB2B-41D32B72C656");
            SomeString = "FA6630D9-05C4-4E79-A649-327AD3819890";

            //on future
            //UserId = new Guid("{7E0F4D7A-4A70-49F0-95F0-8E70C07447FD}");
        }
    }
}
