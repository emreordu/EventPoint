using EventPoint.DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;

namespace EventPoint.Business.Middlewares
{
    public class TransactionMiddleware
    {
        private readonly RequestDelegate _next;
        public TransactionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, ApplicationDbContext dbContext)
        {
            IDbContextTransaction transaction = null;
            try
            {
                transaction = await dbContext.Database.BeginTransactionAsync();

                await _next(context);

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                if (transaction != null)
                    await transaction.RollbackAsync();

                throw;
            }
            finally
            {
                if (transaction != null)
                    await transaction.DisposeAsync();
            }
        }
    }
}