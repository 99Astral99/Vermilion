using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Domain.Common
{
    public abstract class Entity<TId> where TId : EntityId
    {
        public TId Id { get; }

        protected Entity(TId id)
        {
            Id = id ?? throw new Exception("Id не может быть пустым");
        }

        private readonly List<DomainEvent> _domainEvents = new();
        public ICollection<DomainEvent> DomainEvents => _domainEvents;

        protected void Raise(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
