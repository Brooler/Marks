using Marks.Core.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Marks.Database.Repositories
{
    /// <summary>
    /// Repository is layer between db context and application which uses it.
    /// Repository can be used for basic entity operations.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TKey">Identifier type of entity</typeparam>
    public interface IRepository<TEntity, TKey>
        where TEntity : Entity<TKey>
    {
        /// <summary>
        /// Set of all TEntity entities.
        /// </summary>
        /// <returns>Set of all TEntity entities</returns>
        IQueryable<TEntity> Queryable();

        /// <summary>
        /// Gets TEntity entity by identifier.
        /// </summary>
        /// <param name="id">Identifier of entity</param>
        /// <returns>Entity with given identifier</returns>
        Task<TEntity> GetAsync(TKey id);

        /// <summary>
        /// Inserts entity to database.
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        Task InsertAsync(TEntity entity);

        /// <summary>
        /// Updates entity in database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        void Update(TEntity entity);

        /// <summary>
        /// Delete entity by identifier
        /// </summary>
        /// <param name="id">Identifier of entity to be deleted</param>
        Task DeleteAsync(TKey id);

        /// <summary>
        /// Calls SaveChangesAsync() of db context
        /// </summary>
        Task SaveChangesAsync();
    }
}
