using NewsBlog.Base.BaseRepositories;
using System.Threading.Tasks;

namespace NewsBlog.Base.BaseUnitOfWork
{
    public interface IUnitOfWork
    {
        ICrudGenericRepository<T> Repository<T>() where T : class;

        int Commit();

        void Rollback();

        Task<int> CommitAsync();

        Task RollbackAsync();
    }
}