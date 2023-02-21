using MediatR;

namespace EventPoint.Business.Mediator
{
    public interface IQueryHandler<in TQuery, TResult>
    : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }
}