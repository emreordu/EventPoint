using System.Linq.Expressions;

namespace EventPoint.DataAccess.Repository.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null, bool tracked = true);
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        //IQueryable<T> IncludeMultiple<T>(IQueryable<T> query, params Expression<Func<T, object>>[] includes);
    }
}