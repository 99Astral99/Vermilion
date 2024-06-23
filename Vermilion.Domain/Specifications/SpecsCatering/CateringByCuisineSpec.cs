using Ardalis.Specification;
using Vermilion.Domain.Entities;

namespace Vermilion.Domain.Specifications.SpecsCatering
{
    public class CateringByCuisineSpec : Specification<Catering>
    {
        public CateringByCuisineSpec(string cuisineName)
        {
            Query.Include(x => x.Features)
            .Include(x => x.Cuisines)
            .Include(x => x.WorkSchedules)
            .Include(x => x.Reviews)
            .Where(c => c.Cuisines.Any(cu => cu.Name == cuisineName));
        }
    }
}
