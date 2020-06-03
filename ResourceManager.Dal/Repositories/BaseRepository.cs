using Microsoft.EntityFrameworkCore;
using ResourceManager.Core;
using ResourceManager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ResourceManager.Dal.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        protected readonly ResourceManagerContext Context;

        public BaseRepository(ResourceManagerContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// DbSet with entity that this repository stores. 
        /// </summary>              
        protected virtual DbSet<TEntity> Entities => this.Context.Set<TEntity>();

        /// <summary>
        /// Query with entity and related entities.
        /// You should override it in derived classes.
        /// Use it for Select queries (Entities are not attached to Context)
        /// </summary>
        protected virtual IQueryable<TEntity> ComplexEntities => this.Context.Set<TEntity>().AsNoTracking();

        public TEntity GetById(TKey id)
        {
            return this.ComplexEntities.SingleOrDefault(entity => entity.Id.Equals(id));
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await this.ComplexEntities.SingleOrDefaultAsync(entity => entity.Id.Equals(id));
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.ComplexEntities.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.ComplexEntities.ToListAsync();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return this.ComplexEntities.Where(predicate).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.ComplexEntities.Where(predicate).ToListAsync();
        }

        public void Add(TEntity entity)
        {
            this.Entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            this.Entities.Update(entity);
        }

        public void Remove(TEntity entity)
        {
            this.Entities.Remove(entity);
        }
    }
}
