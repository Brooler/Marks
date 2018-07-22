using System.ComponentModel.DataAnnotations;

namespace Marks.Core.Abstractions
{
    /// <summary>
    /// Contains Id property of type TKey, with attribute [Key].
    /// Use this to mark Entities.
    /// </summary>
    /// <typeparam name="TKey">Type of identifier</typeparam>
    public class Entity<TKey>
    {
        /// <summary>
        /// Identifier of entity
        /// </summary>
        [Key]
        public TKey Id { get; set; }
    }
}
