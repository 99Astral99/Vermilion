namespace Vermilion.Domain.Interfaces
{
    public interface IAuditable
    {
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
    }
}
