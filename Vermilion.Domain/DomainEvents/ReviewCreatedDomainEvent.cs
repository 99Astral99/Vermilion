using Vermilion.Domain.Common;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Domain.DomainEvents
{
    public sealed record ReviewCreatedDomainEvent(Guid Id, ReviewId ReviewId, 
        CateringId CateringId, string UserName, int Rating) : DomainEvent(Id);
}
