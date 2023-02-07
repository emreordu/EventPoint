using EventPoint.DataAccess.Repository.Concrete;

namespace EventPoint.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        //IEventRepository Event { get; }
        Repository<T> GetRepository<T>() where T : class;
        Task CommitAsync();
        void Commit();
    }
}