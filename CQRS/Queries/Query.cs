
using CQRSDEMO.CQRS.Caching;
using CQRSDEMO.CQRS.Validation;
using FluentValidation;
using MediatR;

namespace CQRSDEMO.CQRS.Queries
{

    public abstract class Query<TResult, TResultData> : IValidatable, IResultCachable, IRequest<TResult> where TResult : QueryResult<TResultData>
    {



        protected virtual IValidator GetValidator(IValidationMessageProvider messageProvider)
        {
            return null; //default is no validation
        }

        IValidator IValidatable.GetValidator(IValidationMessageProvider messageProvider)
        {
            return this.GetValidator(messageProvider);
        }

        protected virtual CacheConfiguration GetCacheConfiguration()
        {
            return null;
        }

        protected virtual bool UseResultCaching()
        {
            return false;
        }

        CacheConfiguration IResultCachable.GetCacheConfiguration()
        {
            return this.GetCacheConfiguration();
        }

        bool IResultCachable.UseResultCaching()
        {
            return this.UseResultCaching();
        }
    }
}
