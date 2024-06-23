using Ardalis.Specification;
using Vermilion.Domain.Entities;

namespace Vermilion.Domain.Specifications.SpecsCatering
{
    public class CateringByAddressSpec : Specification<Catering>
    {
        public CateringByAddressSpec(string address)
        {
            Query.Where(x => x.Address == address)
            .Include(x => x.Features)
            .Include(x => x.Cuisines)
            .Include(x => x.WorkSchedules)
            .Include(x => x.Reviews);
        }
    }
}
