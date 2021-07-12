using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using var context = new TContext();
            return filter == null
                ? context.Set<TEntity>().AsNoTracking().ToList()
                : context.Set<TEntity>().Where(filter).AsNoTracking().ToList();
        }

        public IQueryable<TEntity> GetAllQueryable(Expression<Func<TEntity, bool>> filter = null)
        {
            using var context = new TContext();
            return filter == null
                ? context.Set<TEntity>().AsNoTracking().AsQueryable()
                : context.Set<TEntity>().Where(filter).AsNoTracking().AsQueryable();
        }
        public IQueryable<TEntity> GetAllQueryable(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool enableTracking = true)
        {
            using var context = new TContext();
            IQueryable<TEntity> query = context.Set<TEntity>();
            if (!enableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (filter != null) query = query.Where(filter);

            return orderBy != null ? orderBy(query) : query;
        }

        public List<TEntity> GetAllThenInclude(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include, Expression<Func<TEntity, bool>> predicate = null)
        {
            using var context = new TContext();
            IQueryable<TEntity> query = context.Set<TEntity>();

            query = include(query);

            return predicate == null
                ? query.ToList()
                : query.Where(predicate).ToList();
        }

        public IQueryable<TEntity> GetAllThenIncludeQueryable(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include, Expression<Func<TEntity, bool>> predicate = null)
        {
            using var context = new TContext();
            IQueryable<TEntity> query = context.Set<TEntity>();

            query = include(query);

            return predicate == null
                ? query.AsQueryable()
                : query.Where(predicate).AsQueryable();
        }

        public bool GetIsTrue(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            return context.Set<TEntity>().AsNoTracking().Any(filter);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            return context.Set<TEntity>().AsNoTracking().FirstOrDefault(filter);
        }

        public bool CheckIfDataExists()
        {
            using var context = new TContext();
            int number = context.Set<TEntity>().AsNoTracking().Count();
            if (number > 0)
                return true;
            return false;
        }

        public int Count()
        {
            using var context = new TContext();
            return context.Set<TEntity>().AsNoTracking().Count();
        }

        public int Max(Expression<Func<TEntity, int>> filter)
        {
            using var context = new TContext();
            return context.Set<TEntity>().AsNoTracking().Max(filter);
        }

        public IQueryable<TEntity> TopList(int take)
        {
            using var context = new TContext();
            return context.Set<TEntity>().AsNoTracking().Take(take);
        }

        public virtual void Add(TEntity entity)
        {
            using var context = new TContext();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            using var context = new TContext();
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            using var context = new TContext();
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }

        public virtual void UpdateModifyProperties(TEntity entity)
        {
            using var context = new TContext();
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }

        public virtual void BulkInsert(List<TEntity> entities)
        {
            using var context = new TContext();
            context.BulkInsert(entities);
        }

        public virtual void BulkDelete(List<TEntity> entities)
        {
            using var context = new TContext();
            context.BulkDelete(entities);
        }

        public virtual void BulkUpdate(List<TEntity> entities)
        {
            using var context = new TContext();
            context.BulkUpdate(entities);
        }

        public virtual void BulkUpdateModifyProperties(List<TEntity> entities, List<string> propertiesToInclude = null, List<string> propertiesToExclude = null, List<string> propertiesToExcludeOnUpdate = null, List<string> propertiesToIncludeOnUpdate = null)
        {
            using var context = new TContext();
            BulkConfig bulkConfig = new BulkConfig
            {
                PropertiesToExclude = propertiesToExclude,
                PropertiesToInclude = propertiesToInclude,
                PropertiesToExcludeOnUpdate = propertiesToExcludeOnUpdate,
                PropertiesToIncludeOnUpdate = propertiesToIncludeOnUpdate
            };
            context.BulkUpdate(entities, bulkConfig);
        }

        public virtual void BulkSynchronize(List<TEntity> entities, BulkConfig bulkConfig)
        {
            using var context = new TContext();
            context.BulkInsertOrUpdateOrDelete(entities, bulkConfig);
        }

        //Task/////////////////////////////////////////Task////


        public async Task<List<TEntity>> GetAllTask(Expression<Func<TEntity, bool>> filter = null)
        {
            await using var context = new TContext();
            return filter == null
               ? await context.Set<TEntity>().AsNoTracking().ToListAsync()
               : await context.Set<TEntity>().Where(filter).AsNoTracking().ToListAsync();
        }


        public async Task<TEntity> GetTask(Expression<Func<TEntity, bool>> filter)
        {
            await using var context = new TContext();
            return await context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(filter);
        }

        public async Task<bool> GetIsTrueTask(Expression<Func<TEntity, bool>> filter)
        {
            await using var context = new TContext();
            return await context.Set<TEntity>().AsNoTracking().AnyAsync(filter);
        }

        public async Task<int> CountTask()
        {
            await using var context = new TContext();
            return await context.Set<TEntity>().AsNoTracking().CountAsync();
        }

        public async Task<List<TEntity>> TopListTask(int take)
        {
            await using var context = new TContext();
            return await context.Set<TEntity>().Take(take).ToListAsync();
        }

        public async Task AddTask(TEntity entity)
        {
            await using var context = new TContext();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await context.SaveChangesAsync();
        }

        public async Task DeleteTask(TEntity entity)
        {
            await using var context = new TContext();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public async Task UpdateTask(TEntity entity)
        {
            await using var context = new TContext();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task BulkInsertTask(List<TEntity> entities)
        {
            await using var context = new TContext();
            await context.BulkInsertAsync(entities);
        }

        public async Task BulkDeleteTask(List<TEntity> entities)
        {
            await using var context = new TContext();
            await context.BulkDeleteAsync(entities);
        }

        public async Task BulkUpdateTask(List<TEntity> entities)
        {
            await using var context = new TContext();
            await context.BulkUpdateAsync(entities);
        }

        public virtual async Task BulkSynchronizeTask(List<TEntity> entities)
        {
            await using var context = new TContext();
            await context.BulkInsertOrUpdateOrDeleteAsync(entities);
        }
    }
}
