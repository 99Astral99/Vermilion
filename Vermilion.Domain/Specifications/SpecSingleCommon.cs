using Ardalis.Specification;
using System.Linq.Expressions;

namespace Vermilion.Domain.Specifications
{
    public sealed class SpecSingleCommon<T> : SingleResultSpecification<T>
    {
        public SpecSingleCommon(Expression<Func<T, bool>> filter, Expression<Func<T, object?>> order, bool orderByDescending = false)
        {
            if (orderByDescending)
                Query.Where(filter).OrderByDescending(order).Take(1);
            else
                Query.Where(filter).OrderBy(order).Take(1);
        }
    }
}
