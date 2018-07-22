using Marks.Core.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marks.Core.Models
{
    public class People : Entity<long>
    {
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }


        public virtual Mark Mark { get; set; }
    }
}
