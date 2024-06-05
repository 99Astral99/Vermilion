using Ardalis.Specification;
using Vermilion.Domain.Entities;

namespace Vermilion.Domain.Specifications.SpecsCatering
{
    public class PendingCateringSpec : Specification<Catering>
    {
        public PendingCateringSpec()
        {
            Query.Where(x => x.IsApproved == false)
            .Include(x => x.Features)
            .Include(x => x.Cuisines)
            .Include(x => x.WorkSchedules)
            .Include(x => x.Reviews);
        }
    }
}
