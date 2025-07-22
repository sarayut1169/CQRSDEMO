using FluentValidation;

namespace CQRSDEMO.CQRS.Validation
{
    public abstract class Validator<T> : AbstractValidator<T>
    {
        private IValidationMessageProvider _messageProvider;

        public Validator(IValidationMessageProvider messageProvider)
        {
            _messageProvider = messageProvider;
        }

        protected virtual string GetMessage(string code)
        {
            return _messageProvider.GetMessage(code);
        }


    }
}
