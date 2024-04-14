using Ardalis.Specification;
using Vermilion.Domain.Entities;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Domain.Specifications.SpecsCatering
{
    public class CateringByIdSpec : Specification<Catering>
    {
        public CateringByIdSpec(CateringId Id)
        {
            Query.Where(x => x.Id == Id)
                .Include(x => x.Features)
                .Include(x => x.Cuisines)
                .Include(x => x.Reviews);
        }
    }
}
