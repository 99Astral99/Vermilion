using Ardalis.Specification;
using Vermilion.Domain.Entities;

namespace Vermilion.Domain.Specifications.SpecsCatering
{
    public class CateringByFeatureSpec : Specification<Catering>
    {
        public CateringByFeatureSpec(string featureName)
        {
            Query.Include(x => x.Features)
            .Include(x => x.Cuisines)
            .Include(x => x.WorkSchedules)
            .Include(x => x.Reviews)
            .Where(c => c.Features.Any(cu => cu.Name == featureName));
        }
    }
}
