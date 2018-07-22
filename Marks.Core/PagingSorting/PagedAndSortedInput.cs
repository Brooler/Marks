using System.ComponentModel.DataAnnotations;

namespace Marks.Core.PagingSorting
{
    /// <summary>
    /// Object contains needed props for paging and sorting list.
    /// </summary>
    public class PagedAndSortedInput
    {
        /// <summary>
        /// Count of records to skip.
        /// </summary>
        [Range(0, int.MaxValue)]
        public int Skip { get; set; }

        /// <summary>
        /// Count of records to show on one page.
        /// </summary>
        [Range(1, int.MaxValue)]
        public int Take { get; set; }

        /// <summary>
        /// Sorting in format "[PropertyName] asc/desc,[NextPropertyName] asc/desc".
        /// </summary>
        public string Sorting { get; set; }

        /// <summary>
        /// Validates if all properties has correct values and set defaults if something is missed.
        /// </summary>
        public void ValidateAndSetDefaults()
        {
            Skip = Skip >= 0 ? Skip : 0;
            Take = Take > 0 ? Take : 10;
            Sorting = !string.IsNullOrEmpty(Sorting) ? Sorting : "Id desc";
        }
    }
}
