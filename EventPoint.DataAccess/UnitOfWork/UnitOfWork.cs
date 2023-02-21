using EventPoint.DataAccess.Data;
using EventPoint.DataAccess.Repository.Concrete;
using System.Collections.Concurrent;

namespace EventPoint.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;
        private readonly ConcurrentDictionary<string, object> keyValuePairs= new ConcurrentDictionary<string, object>();
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Repository<T> GetRepository<T>() where T : class
        {
            return (Repository<T>)keyValuePairs.GetOrAdd(key:typeof(T).Name, value:new Repository<T>(_dbContext));
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public async Task CommitAsync(CancellationToken cancellationToken)
        {
               await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}