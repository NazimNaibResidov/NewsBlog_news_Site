using Microsoft.EntityFrameworkCore;
using NewsBlog.Base.BaseAuditable;
using NewsBlog.Base.BaseRepositories;
using NewsBlog.Base.BaseUnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NewsBlog.Repositories
{
    public class EFCrudGenericRepository<T> : ICrudGenericRepository<T> where T : class
    {
        private readonly DbContext _context;

        private readonly IUnitOfWork _unitOfWork;

        private DbSet<T> _dbSet;

        public EFCrudGenericRepository(DbContext context)
        {
            _context = context;
            _unitOfWork = new EFUnitOfWork(context);
            _dbSet = _context.Set<T>();
        }

        private void Detached(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        private void Detached(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                Detached(entity);
            }
        }

        private void UnchangedProperty(T entity)
        {
            if (entity is IAuditableEntity)
            {
                _context.Entry(entity).Property("CreatedDate").IsModified = false;
                _context.Entry(entity).Property("CreatedBy").IsModified = false;
            }
        }

        #region Add operations

        public void Add(T entity, bool isUnCommitted = false)
        {
            _dbSet.Add(entity);

            if (isUnCommitted)
            {
                _unitOfWork.Commit();

                Detached(entity);
            }
        }

        public async Task AddAsync(T entity, bool isUnCommitted = false)
        {
            await _dbSet.AddAsync(entity);

            if (isUnCommitted)
            {
                await _unitOfWork.CommitAsync();

                Detached(entity);
            }
        }

        public void AddRange(ICollection<T> entities, bool isUnCommitted = false)
        {
            _dbSet.AddRange(entities);

            if (isUnCommitted)
            {
                _unitOfWork.Commit();

                Detached(entities);
            }
        }

        public async Task AddRangeAsync(ICollection<T> entities, bool isUnCommitted = false)
        {
            await _dbSet.AddRangeAsync(entities);

            if (isUnCommitted)
            {
                await _unitOfWork.CommitAsync();

                Detached(entities);
            }
        }

        #endregion Add operations

        #region Delete operations

        public void Delete(T entity, bool isUnCommitted = false)
        {
            _dbSet.Remove(entity);

            if (isUnCommitted)
            {
                _unitOfWork.Commit();
            }
        }

        public async Task DeleteAsync(T entity, bool isUnCommitted = false)
        {
            _dbSet.Remove(entity);

            if (isUnCommitted)
            {
                await _unitOfWork.CommitAsync();
            }
        }

        public void DeleteRange(ICollection<T> entities, bool isUnCommitted = false)
        {
            _dbSet.RemoveRange(entities);

            if (isUnCommitted)
            {
                _unitOfWork.Commit();
            }
        }

        public async Task DeleteRangeAsync(ICollection<T> entities, bool isUnCommitted = false)
        {
            try
            {
                _dbSet.RemoveRange(entities);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (isUnCommitted)
            {
                await _unitOfWork.CommitAsync();
            }
        }

        #endregion Delete operations

        #region Update operations

        public void Update(T updated, bool isUnCommitted = false)
        {
            _dbSet.Attach(updated);

            _context.Entry(updated).State = EntityState.Modified;

            UnchangedProperty(updated);

            if (isUnCommitted)
            {
                _unitOfWork.Commit();

                Detached(updated);
            }
        }

        public async Task UpdateAsync(T updated, bool isUnCommitted = false)
        {
            _dbSet.Attach(updated);

            _context.Entry(updated).State = EntityState.Modified;

            UnchangedProperty(updated);

            if (isUnCommitted)
            {
                await _unitOfWork.CommitAsync();

                Detached(updated);
            }
        }

        public void UpdateRange(ICollection<T> entities, bool isUnCommitted = false)
        {
            foreach (var updated in entities)
            {
                _dbSet.Attach(updated);

                _context.Entry(updated).State = EntityState.Modified;

                UnchangedProperty(updated);
            }

            if (isUnCommitted)
            {
                _unitOfWork.Commit();

                Detached(entities);
            }
        }

        public async Task UpdateRangeAsync(ICollection<T> entities, bool isUnCommitted = false)
        {
            try
            {
                foreach (var updated in entities)
                {
                    _dbSet.Attach(updated);

                    _context.Entry(updated).State = EntityState.Modified;

                    UnchangedProperty(updated);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (isUnCommitted)
            {
                await _unitOfWork.CommitAsync();

                Detached(entities);
            }
        }

        #endregion Update operations

        #region Select operations

        public DataTable SelectSqlRaw(string sqlQuery)
        {
            DataTable dataTable = null;

            var connection = _context.Database.GetDbConnection();

            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);

            using var cmd = dbFactory.CreateCommand();
            try
            {
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlQuery;

                using DbDataAdapter adapter = dbFactory.CreateDataAdapter();
                adapter.SelectCommand = cmd;

                if (cmd.Connection.State == ConnectionState.Closed) cmd.Connection.Open();

                adapter.Fill(dataTable);

                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                if (cmd.Connection.State != ConnectionState.Closed) cmd.Connection.Close();

                throw ex;
            }

            return dataTable;
        }

        public IQueryable<T> Query()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<IQueryable<T>> QueryAsync()
        {
            var result = await _dbSet.AsQueryable().ToListAsync();
            return result.AsQueryable();
        }

        public ICollection<T> FindAll()
        {
            return _dbSet.ToList();
        }

        public async Task<ICollection<T>> FindAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public bool FindAny(Expression<Func<T, bool>> match)
        {
            return _dbSet.Any(match);
        }

        public async Task<bool> FindAnyAsync(Expression<Func<T, bool>> match)
        {
            return await _dbSet.AnyAsync(match);
        }

        public ICollection<T> FindBy(Expression<Func<T, bool>> match)
        {
            return _dbSet.Where(match).ToList();
        }

        public async Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> match)
        {
            return await _dbSet.Where(match).ToListAsync();
        }

        public T FindFirst(Expression<Func<T, bool>> match)
        {
            return _dbSet.FirstOrDefault(match);
        }

        public async Task<T> FindFirstAsync(Expression<Func<T, bool>> match)
        {
            return await _dbSet.FirstOrDefaultAsync(match);
        }

        public T FindById(object id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> FindByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        #endregion Select operations

        #region ExecuteSqlRaw

        public int ExecuteSqlRaw(string sqlQuery)
        {
            return _context.Database.ExecuteSqlRaw(sqlQuery);
        }

        public async Task<int> ExecuteSqlRawAsync(string sqlQuery)
        {
            return await _context.Database.ExecuteSqlRawAsync(sqlQuery);
        }

        #endregion ExecuteSqlRaw
    }
}