using Ardalis.Specification;

namespace Vermilion.Domain.Repositories
{
    public interface IRepositoryReadOnly<T> : IReadRepositoryBase<T> where T : class { }
}
