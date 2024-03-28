using Ardalis.Specification.EntityFrameworkCore;
using Vermilion.Domain.Repositories;

namespace Vermilion.Infrastructure
{
    public class EfRepository<T> : RepositoryBase<T>, IRepositoryReadOnly<T>, IRepository<T> where T : class
    {
        public EfRepository(VermilionDbContext dbContext) : base(dbContext)
        {

        }
    }
}
