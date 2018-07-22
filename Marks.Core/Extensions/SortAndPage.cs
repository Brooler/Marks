using Marks.Core.PagingSorting;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Marks.Core.Extensions
{
    public static class SortAndPage
    {
        /// <summary>
        /// Sorts and pages input set of entities on query level.
        /// Sorting implemented using Linq.Dynamic package.
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="entities">Set of entities to be sorted and paged</param>
        /// <param name="input">Object with sorting and paging</param>
        /// <returns>Query with sorting and paging</returns>
        public static IQueryable<TEntity> SortAndPageBy<TEntity>(this IQueryable<TEntity> entities, PagedAndSortedInput input)
        {
            return entities
                .OrderBy(input.Sorting)
                .Skip(input.Skip)
                .Take(input.Take);
        }
    }
}
