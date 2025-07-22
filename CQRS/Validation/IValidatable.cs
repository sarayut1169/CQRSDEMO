using FluentValidation;

namespace CQRSDEMO.CQRS.Validation
{
    public interface IValidatable
    {
        IValidator GetValidator(IValidationMessageProvider messageProvider);
    }
}
