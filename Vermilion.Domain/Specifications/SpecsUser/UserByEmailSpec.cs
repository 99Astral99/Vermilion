using Ardalis.Specification;
using Vermilion.Domain.Entities;

namespace Vermilion.Domain.Specifications.SpecsUser
{
    public class UserByEmailSpec : Specification<User>
    {
        public UserByEmailSpec(string Email)
        {
            Query.Where(e => e.Email == Email)
                .Include(x => x.Reviews)
                .AsNoTracking();
        }
    }
}
