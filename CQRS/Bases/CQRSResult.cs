
using CQRSDEMO.CQRS.Validation;
using FluentValidation.Results;
using System.Net;



namespace CQRSDEMO.CQRS.Bases
{
    public abstract class CQRSResult<T> : IResult<T>
    {
        public bool IsSuccess { get; set; }
        public int? Total { get; set; }
        public string? Redirect { get; set; }
        public string? ErrorMessages { get; set; }
        public int? StatusCode { get; set; }
        public T ResultData { get; set; }
        public ValidationResult ValidationResult { get; internal set; }

        public List<InformationMessage> Messages { get; }

        public CQRSResult()
        {
            this.Messages = new List<InformationMessage>();
            this.StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        void IHaveValidationResult.SetValidationResult(ValidationResult validationResult)
        {
            this.ValidationResult = validationResult;
        }
    }
}
