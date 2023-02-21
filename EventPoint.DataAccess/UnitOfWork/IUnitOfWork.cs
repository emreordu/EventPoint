using EventPoint.DataAccess.Repository.Concrete;

namespace EventPoint.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        Repository<T> GetRepository<T>() where T : class;
        Task CommitAsync(CancellationToken cancellationToken);
        void Commit();
    }
}