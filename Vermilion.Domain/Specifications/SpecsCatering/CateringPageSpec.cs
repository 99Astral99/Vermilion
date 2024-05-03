using Ardalis.Specification;
using Vermilion.Domain.Entities;

namespace Vermilion.Domain.Specifications.SpecsCatering
{
    public class CateringPageSpec : Specification<Catering>
    {
        public CateringPageSpec(int skip, int take)
        {
            take = take > 0 ? take : int.MaxValue;
            Query
                .Include(x => x.Features)
                .Include(x => x.Cuisines)
                .Skip(skip)
                .Take(take)
                .AsNoTracking();
        }
    }
}
