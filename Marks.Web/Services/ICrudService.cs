using Marks.Core.Abstractions;
using Marks.Core.PagingSorting;
using Marks.Web.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Marks.Web.Services
{
    /// <summary>
    /// Service for crud operations.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TKey">Identifier type of entity</typeparam>
    /// <typeparam name="TViewModel">ViewModel type</typeparam>
    public interface ICrudService<TEntity, TKey, TViewModel>
        where TEntity : Entity<TKey>
        where TViewModel : EntityDto<TKey>
    {
        /// <summary>
        /// Gets paged and sorted entities from database and mapps them to ViewModels.
        /// </summary>
        /// <param name="input">Object with paging and sorting</param>
        /// <param name="includings">Expressions with properties to include</param>
        /// <returns>Paged and sorted output of ViewModels</returns>
        Task<PagedOutput<TViewModel>> GetAll(PagedAndSortedInput input, params Expression<Func<TEntity, object>>[] includings);

        /// <summary>
        /// Gets entity by id and mapps it to ViewModel.
        /// </summary>
        /// <param name="id">Identifier of entity</param>
        /// <returns>ViewModel with given identifier</returns>
        Task<TViewModel> Get(TKey id);

        /// <summary>
        /// Mapps given ViewModel to entity, then inserts it to database.
        /// </summary>
        /// <param name="model">Input ViewModel</param>
        Task Create(TViewModel model);

        /// <summary>
        /// Mapps given ViewModel to entity, then updates it in database.
        /// </summary>
        /// <param name="model">Input ViewModel</param>
        Task Update(TViewModel model);

        /// <summary>
        /// Deletes entity by given Id.
        /// </summary>
        /// <param name="id">Identifier of entity to be deleted</param>
        Task Delete(TKey id);
    }
}
