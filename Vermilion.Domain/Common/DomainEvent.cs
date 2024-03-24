using MediatR;

namespace Vermilion.Domain.Common
{
    public record DomainEvent(Guid Id) : INotification;
}
