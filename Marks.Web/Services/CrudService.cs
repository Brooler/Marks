using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Marks.Core.Abstractions;
using Marks.Database.Repositories;
using Marks.Core.PagingSorting;
using Microsoft.EntityFrameworkCore;
using Marks.Core.Extensions;
using Marks.Web.ViewModels;

namespace Marks.Web.Services
{
    /// <summary>
    /// Service for crud operations.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TKey">Identifier type of entity</typeparam>
    /// <typeparam name="TViewModel">ViewModel type</typeparam>
    public class CrudService<TEntity, TKey, TViewModel> : ICrudService<TEntity, TKey, TViewModel>
        where TEntity : Entity<TKey>
        where TViewModel : EntityDto<TKey>
    {
        private readonly IRepository<TEntity, TKey> _repository;
        private readonly IMapper _mapper;

        public CrudService(IRepository<TEntity, TKey> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Mapps given ViewModel to entity, then inserts it to database.
        /// </summary>
        /// <param name="model">Input ViewModel</param>
        public virtual async Task Create(TViewModel model)
        {
            var entity = _mapper.Map<TEntity>(model);

            await _repository.InsertAsync(entity);

            await _repository.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes entity by given Id.
        /// </summary>
        /// <param name="id">Identifier of entity to be deleted</param>
        public virtual async Task Delete(TKey id)
        {
            await _repository.DeleteAsync(id);

            await _repository.SaveChangesAsync();
        }

        /// <summary>
        /// Gets entity by id and mapps it to ViewModel.
        /// </summary>
        /// <param name="id">Identifier of entity</param>
        /// <returns>ViewModel with given identifier</returns>
        public virtual async Task<TViewModel> Get(TKey id)
        {
            var entity = await _repository.GetAsync(id);

            return _mapper.Map<TViewModel>(entity);
        }

        /// <summary>
        /// Gets paged and sorted entities from database and mapps them to ViewModels.
        /// </summary>
        /// <param name="input">Object with paging and sorting</param>
        /// <param name="includings">Expressions with properties to include</param>
        /// <returns>Paged and sorted output of ViewModels</returns>
        public async Task<PagedOutput<TViewModel>> GetAll(PagedAndSortedInput input, params Expression<Func<TEntity, object>>[] includings)
        {
            var queryable = _repository.Queryable();
            var result = await queryable.SortAndPageBy(input).IncludeMultiple(includings).ToListAsync();
            var count = await queryable.CountAsync();

            return new PagedOutput<TViewModel>(_mapper.Map<List<TViewModel>>(result), count);
        }

        /// <summary>
        /// Mapps given ViewModel to entity, then updates it in database.
        /// </summary>
        /// <param name="model">Input ViewModel</param>
        public virtual async Task Update(TViewModel model)
        {
            var entity = await _repository.GetAsync(model.Id);

            entity = _mapper.Map(model, entity);

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }
    }
}
