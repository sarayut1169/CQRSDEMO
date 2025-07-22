using CQRSDEMO.CQRS.Validation;
using CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer;
using FluentValidation;

namespace CQRSDEMO.Modules.Customer.Commands.Delete
{
    public class DeleteCustomerCommandValidator : Validator<GetCustomerQuery>
    {
        public DeleteCustomerCommandValidator(IValidationMessageProvider messageProvider) : base(messageProvider)
        {
        }
    }
}
