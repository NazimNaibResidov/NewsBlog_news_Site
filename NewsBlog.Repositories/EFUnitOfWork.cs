using Microsoft.EntityFrameworkCore;
using NewsBlog.Base.BaseRepositories;
using NewsBlog.Base.BaseUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public Dictionary<Type, object> Repositories
        {
            get { return _repositories; }
            set { Repositories = value; }
        }

        public EFUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICrudGenericRepository<T> Repository<T>() where T : class
        {
            if (Repositories.Keys.Contains(typeof(T)))
            {
                return Repositories[typeof(T)] as ICrudGenericRepository<T>;
            }

            ICrudGenericRepository<T> repo = new EFCrudGenericRepository<T>(_dbContext);

            Repositories.Add(typeof(T), repo);

            return repo;
        }

        public async Task<int> CommitAsync()
        {
            int result = 0;
            try
            {
                result = await _dbContext.SaveChangesAsync();

                _dbContext.DetachAllEntries();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return result;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Rollback()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        public async Task RollbackAsync()
        {
            foreach (var entity in _dbContext.ChangeTracker.Entries())
            {
                await entity.ReloadAsync();
            }
        }
    }
}