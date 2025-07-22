
using CQRSDEMO.CQRS.Validation;
using FluentValidation.Results;

namespace CQRSDEMO.CQRS.Bases
{
    public interface IResult : IHaveValidationResult
    {
        bool IsSuccess { get; set; }
        ValidationResult ValidationResult { get; }

        List<InformationMessage> Messages { get; }
    }

    public interface IResult<T> : IResult
    {
        T ResultData { get; set; }

    }
}
