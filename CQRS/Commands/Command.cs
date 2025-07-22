
using CQRSDEMO.CQRS.Validation;
using FluentValidation;
using MediatR;

namespace CQRSDEMO.CQRS.Commands
{
    public abstract class Command<TResult, TResultData> : IValidatable, IRequest<TResult> where TResult : CommandResult<TResultData>
    {
        protected virtual IValidator GetValidator(IValidationMessageProvider messageProvider)
        {
            return null; //default is no validation
        }

        IValidator IValidatable.GetValidator(IValidationMessageProvider messageProvider)
        {
            return this.GetValidator(messageProvider);
        }
    }
}
