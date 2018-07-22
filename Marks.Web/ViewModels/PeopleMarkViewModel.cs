using Marks.Core.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Marks.Web.ViewModels
{
    /// <summary>
    /// ViewModel people and mark.
    /// </summary>
    public class PeopleMarkViewModel : EntityDto<long>
    {
        /// <summary>
        /// First name + Last name.
        /// </summary>
        [Required(ErrorMessage = "Full Name is required and should be in format - \"{FirstName} {LastName}\".")]
        [RegularExpression("^[a-zA-Z]+ [a-zA-Z]+$")]
        public string FullName { get; set; }

        /// <summary>
        /// People mark.
        /// </summary>
        [Range(0, 5, ErrorMessage = "Mark should be in range [0, 5].")]
        public int Mark { get; set; }
    }
}
