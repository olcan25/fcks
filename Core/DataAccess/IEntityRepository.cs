using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Abstract;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> filter = null);
        IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool enableTracking = true);
        List<T> GetAllThenInclude(Func<IQueryable<T>, IIncludableQueryable<T, object>> include, Expression<Func<T, bool>> predicate = null);
        IQueryable<T> GetAllThenIncludeQueryable(Func<IQueryable<T>, IIncludableQueryable<T, object>> include, Expression<Func<T, bool>> predicate = null);
        bool GetIsTrue(Expression<Func<T, bool>> filter);
        int Count();
        bool CheckIfDataExists();
        int Max(Expression<Func<T, int>> filter);
        IQueryable<T> TopList(int take);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        void UpdateModifyProperties(T entity);
        void BulkInsert(List<T> entities);
        void BulkDelete(List<T> entities);
        void BulkUpdate(List<T> entities);
        void BulkUpdateModifyProperties(List<T> entities, List<string> propertiesToInclude = null, List<string> propertiesToExclude = null, List<string> propertiesToExcludeOnUpdate = null, List<string> propertiesToIncludeOnUpdate = null);
        void BulkSynchronize(List<T> entities, BulkConfig bulkConfig = null);


        //Task
        Task<List<T>> GetAllTask(Expression<Func<T, bool>> filter = null);
        Task<T> GetTask(Expression<Func<T, bool>> filter);
        Task<bool> GetIsTrueTask(Expression<Func<T, bool>> filter);
        Task<int> CountTask();
        Task<List<T>> TopListTask(int take);
        Task AddTask(T entity);
        Task DeleteTask(T entity);
        Task UpdateTask(T entity);
        Task BulkInsertTask(List<T> entities);
        Task BulkDeleteTask(List<T> entities);
        Task BulkUpdateTask(List<T> entities);
        Task BulkSynchronizeTask(List<T> entities);
    }
}
