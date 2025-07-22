using FluentValidation.Results;

namespace CQRSDEMO.CQRS.Validation
{
    public interface IHaveValidationResult
    {
        void SetValidationResult(ValidationResult validationResult);
    }
}
