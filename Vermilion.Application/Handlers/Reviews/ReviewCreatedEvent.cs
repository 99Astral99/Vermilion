using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Application.Handlers.Reviews
{
    public record ReviewCreatedEvent
    {
        public ReviewId ReviewId { get; init; }
        public CateringId CateringId { get; init; }
        public string UserName { get; init; } = string.Empty;
        public int Rating { get; init; }
    }
}
