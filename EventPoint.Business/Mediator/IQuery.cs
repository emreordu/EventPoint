using MediatR;

namespace EventPoint.Business.Mediator
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}