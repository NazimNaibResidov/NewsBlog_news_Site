using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NewsBlog.Base.BaseRepositories
{
    public partial interface ICrudGenericRepository<T> where T : class
    {
        #region Async operations

        Task<T> FindByIdAsync(object id);

        Task<bool> FindAnyAsync(Expression<Func<T, bool>> match);

        Task<T> FindFirstAsync(Expression<Func<T, bool>> match);

        Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> match);

        Task<ICollection<T>> FindAllAsync();

        Task AddAsync(T entity, bool isUnCommitted = false);

        Task AddRangeAsync(ICollection<T> entities, bool isUnCommitted = false);

        Task UpdateAsync(T updated, bool isUnCommitted = false);

        Task UpdateRangeAsync(ICollection<T> entities, bool isUnCommitted = false);

        Task DeleteAsync(T entity, bool isUnCommitted = false);

        Task DeleteRangeAsync(ICollection<T> entities, bool isUnCommitted = false);

        Task<int> ExecuteSqlRawAsync(string sqlQuery);

        #endregion Async operations

        #region Sync operations

        DataTable SelectSqlRaw(string sqlQuery);

        IQueryable<T> Query();
        Task<IQueryable<T>> QueryAsync();

        T FindById(object id);

        bool FindAny(Expression<Func<T, bool>> match);

        T FindFirst(Expression<Func<T, bool>> match);

        ICollection<T> FindBy(Expression<Func<T, bool>> match);

        ICollection<T> FindAll();

        void Add(T entity, bool isUnCommitted = false);

        void AddRange(ICollection<T> entities, bool isUnCommitted = false);

        void Update(T updated, bool isUnCommitted = false);

        void UpdateRange(ICollection<T> entities, bool isUnCommitted = false);

        void Delete(T entity, bool isUnCommitted = false);

        void DeleteRange(ICollection<T> entities, bool isUnCommitted = false);

        int ExecuteSqlRaw(string sqlQuery);

        #endregion Sync operations
    }
}