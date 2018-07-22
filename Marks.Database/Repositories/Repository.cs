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
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : Entity<TKey>
    {
        private readonly AppDbContext _db;

        public Repository(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Delete entity by identifier
        /// </summary>
        /// <param name="id">Identifier of entity to be deleted</param>
        public async Task DeleteAsync(TKey id)
        {
            var entity = await GetAsync(id);

            _db.Remove(entity);
        }

        /// <summary>
        /// Gets TEntity entity by identifier.
        /// </summary>
        /// <param name="id">Identifier of entity</param>
        /// <returns>Entity with given identifier</returns>
        public async Task<TEntity> GetAsync(TKey id)
        {
            return await _db.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Inserts entity to database.
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        public async Task InsertAsync(TEntity entity)
        {
            await _db.AddAsync(entity);
        }

        /// <summary>
        /// Set of all TEntity entities.
        /// </summary>
        /// <returns>Set of all TEntity entities</returns>
        public IQueryable<TEntity> Queryable()
        {
            return _db.Set<TEntity>();
        }

        /// <summary>
        /// Updates entity in database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        public void Update(TEntity entity)
        {
            _db.Update(entity);
        }

        /// <summary>
        /// Calls SaveChangesAsync() of db context
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
