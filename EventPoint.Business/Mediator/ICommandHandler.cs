using MediatR;

namespace EventPoint.Business.Mediator
{
    public interface ICommandHandler<in TCommand, TResult>
    : IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {
    }
}