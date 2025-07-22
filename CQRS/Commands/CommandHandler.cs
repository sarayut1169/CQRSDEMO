using MediatR;

namespace CQRSDEMO.CQRS.Commands
{
    public abstract class CommandHandler<TCommand, TResult, TResultData> : IRequestHandler<TCommand, TResult>
        where TCommand : Command<TResult, TResultData>
        where TResult : CommandResult<TResultData>
    {
        public Task<TResult> Handle(TCommand request, CancellationToken cancellationToken)
        {
            return OnExecute(request, cancellationToken);
        }

        protected abstract Task<TResult> OnExecute(TCommand command, CancellationToken cancellationToken);
    }
}
