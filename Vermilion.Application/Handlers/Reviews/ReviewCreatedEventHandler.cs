using MassTransit;
using MediatR;
using Vermilion.Domain.DomainEvents;

namespace Vermilion.Application.Handlers.Reviews
{
    public sealed class ReviewCreatedEventHandler
        : INotificationHandler<ReviewCreatedDomainEvent>
    {
        private readonly IBus _bus;

        public ReviewCreatedEventHandler(IBus bus)
        {
            _bus = bus;
        }

        public async Task Handle(ReviewCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _bus.Send(new ReviewCreatedEvent
            {
                CateringId = notification.CateringId,
                Rating = notification.Rating,
                ReviewId = notification.ReviewId,
                UserName = notification.UserName,
            }, cancellationToken);
        }
    }
}
