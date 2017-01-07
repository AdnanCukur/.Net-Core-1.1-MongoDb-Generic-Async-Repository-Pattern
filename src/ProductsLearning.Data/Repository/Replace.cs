﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace ProductsLearning.Data.Repository
{
    public partial class Repository<T> where T : IEntity
    {
        /// <summary>
        /// replace an existing entity
        /// </summary>
        /// <param name="entity">entity</param>
        public virtual void Replace(T entity)
        {
            Retry(() =>
            {
                return Collection.ReplaceOne(i => i.Id == entity.Id, entity);
            });
        }

        /// <summary>
        /// replace collection of entities
        /// </summary>
        /// <param name="entities">collection of entities</param>
        public void Replace(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                Replace(entity);
            }
        }
        #region async
        /// <summary>
        /// replace an existing entity
        /// </summary>
        /// <param name="entity">entity</param>
        public virtual async Task ReplaceAsync(T entity)
        {
            await Retry(async () =>
            {
                return await Collection.ReplaceOneAsync(i => i.Id == entity.Id, entity);
            });
        }
        /// <summary>
        /// replace collection of entities
        /// </summary>
        /// <param name="entities">collection of entities</param>
        public async Task ReplaceAsync(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                await ReplaceAsync(entity);
            }
        }
        #endregion
    }
}
