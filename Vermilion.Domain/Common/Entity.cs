namespace Vermilion.Domain.Common
{
    public abstract class Entity<TId> where TId : class
    {
        public TId Id { get; }

        protected Entity(TId id)
        {
            Id = id ?? throw new Exception("Id can't be null");
        }

        protected Entity() { }
        private readonly List<DomainEvent> _domainEvents = new();
        public ICollection<DomainEvent> DomainEvents => _domainEvents;

        protected void Raise(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
