using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace EventPoint.DataAccess.Repository.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, bool tracked = true, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, int pageSize = 3, int pageNumber = 1);
        Task CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}