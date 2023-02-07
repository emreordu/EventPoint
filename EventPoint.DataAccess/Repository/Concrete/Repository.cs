using EventPoint.DataAccess.Data;
using EventPoint.DataAccess.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace EventPoint.DataAccess.Repository.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }
        public async Task DeleteAsync(T entity)
        {
            dbSet.Entry(entity).State = EntityState.Detached;
            dbSet.Remove(entity);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> query = dbSet;
            return await query.AsNoTracking().ToListAsync();
        }
        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<T> UpdateAsync(T entity)
        {
            dbSet.Entry(entity).State = EntityState.Modified;
            dbSet.Update(entity);
            return entity;
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }
        public IQueryable<T> IncludeMultiple<T>(IQueryable<T> query, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }
            return query;
        }
        public async Task<T> QuerySingleAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = dbSet;
            query = query.AsNoTracking(); if (include != null)
            {
                query = include(query);
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            var result = await query.SingleOrDefaultAsync();
            return result;
        }
    }
}