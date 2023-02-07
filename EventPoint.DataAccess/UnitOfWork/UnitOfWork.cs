using EventPoint.DataAccess.Data;
using EventPoint.DataAccess.Repository.Concrete;
using Microsoft.Extensions.Configuration;

namespace EventPoint.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;
        private IConfiguration _configuration;
        private readonly CancellationToken cancellationToken;
        public UnitOfWork(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            //Event = new EventRepository(_dbContext);
        }
        public Repository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_dbContext);
            //fix creating new instance issue every time method gets called. !!
        }
        //public IEventRepository Event { get; private set; }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}