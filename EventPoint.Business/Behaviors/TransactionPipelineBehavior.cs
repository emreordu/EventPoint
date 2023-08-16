using EventPoint.DataAccess.Data;
using EventPoint.DataAccess.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;

namespace EventPoint.Business.Behaviors
{
    public class TransactionPipelineBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        public TransactionPipelineBehavior(ApplicationDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response;
            IDbContextTransaction transaction = null;
            try
            {
                //try to implement transaction on UnitOfWork. birlikte deneyeceğiz.
                transaction = await _dbContext.Database.BeginTransactionAsync();
                response = await next();
                await _unitOfWork.CommitAsync(cancellationToken);
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
            return response;
        }
    }
}