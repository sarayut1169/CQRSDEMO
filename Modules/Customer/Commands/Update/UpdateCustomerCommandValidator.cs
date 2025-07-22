using CQRSDEMO.CQRS.Validation;
using CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer;
using FluentValidation;

namespace CQRSDEMO.Modules.Customer.Commands.Update
{
    public class UpdateCustomerCommandValidator : Validator<GetCustomerQuery>
    {
        public UpdateCustomerCommandValidator(IValidationMessageProvider messageProvider) : base(messageProvider)
        {
        }
    }
}
