using Ardalis.Specification;

namespace Vermilion.Domain.Repositories
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class { }
}
