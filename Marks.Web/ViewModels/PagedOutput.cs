using System.Collections.Generic;

namespace Marks.Web.ViewModels
{
    /// <summary>
    /// Object with Items of type T to show on current page and total count of results for implementing paging on frontend.
    /// </summary>
    /// <typeparam name="T">Type of result records</typeparam>
    public class PagedOutput<T>
    {
        public PagedOutput(List<T> items, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }

        /// <summary>
        /// Items to show on current page.
        /// </summary>
        public List<T> Items { get; set; }
        
        /// <summary>
        /// Total number of requested records.
        /// </summary>
        public int TotalCount { get; set; }
    }
}
