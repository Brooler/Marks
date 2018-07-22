using System.ComponentModel.DataAnnotations;

namespace Marks.Core.Abstractions
{
    /// <summary>
    /// Contains Id property of type TKey, with attribute [Key].
    /// Use this to mark Dtos with identifier
    /// </summary>
    /// <typeparam name="TKey">Type of identifier</typeparam>
    public class EntityDto<TKey>
    {
        /// <summary>
        /// Identifier of Dto
        /// </summary>
        [Key]
        public TKey Id { get; set; }
    }
}
