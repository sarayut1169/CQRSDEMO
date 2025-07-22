using MediatR;

namespace CQRSDEMO.CQRS.Queries
{
    public abstract class QueryHandler<TQuery, TResult, TResultData> : IRequestHandler<TQuery, TResult>
        where TQuery : Query<TResult, TResultData>
        where TResult : QueryResult<TResultData>
    {

        public Task<TResult> Handle(TQuery query, CancellationToken cancellationToken)
        {
            return OnExecute(query, cancellationToken);
        }

        protected abstract Task<TResult> OnExecute(TQuery query, CancellationToken cancellationToken);


    }
}
