using Marks.Core.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marks.Core.Models
{
    public class Mark : Entity<long>
    {
        [Range(0, 5)]
        public int Value { get; set; }


        public long PeopleId { get; set; }
        
        public virtual People People { get; set; }
    }
}
