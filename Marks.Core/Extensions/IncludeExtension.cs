using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Marks.Core.Extensions
{
    public static class IncludeExtension
    {
        /// <summary>
        /// Calls Include method for each include expression passed.
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <typeparam name="TProperty">Include property type</typeparam>
        /// <param name="entities">Set of entities where include should be called</param>
        /// <param name="includings">Include expressions</param>
        /// <returns>Set of entities whith included properties</returns>
        public static IQueryable<TEntity> IncludeMultiple<TEntity, TProperty>(this IQueryable<TEntity> entities, params Expression<Func<TEntity, TProperty>>[] includings)
            where TEntity : class
        {
            var result = entities;

            foreach(var include in includings)
            {
                result = entities.Include(include);
            }

            return result;
        }
    }
}
