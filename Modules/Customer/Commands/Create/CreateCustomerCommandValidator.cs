using CQRSDEMO.CQRS.Validation;
using CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer;
using FluentValidation;

namespace CQRSDEMO.Modules.Customer.Commands.Create
{
    public class CreateCustomerCommandValidator : Validator<GetCustomerQuery>
    {
        public CreateCustomerCommandValidator(IValidationMessageProvider messageProvider) : base(messageProvider)
        {
        }
    }
}
