using MediatR;

namespace EventPoint.Business.Mediator
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }
}