using CQRSDEMO.CQRS.Validation;
using CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer;
using FluentValidation;

namespace CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer
{
    public class GetCustomerQueryValidator : Validator<GetCustomerQuery>
    {
        public GetCustomerQueryValidator(IValidationMessageProvider messageProvider) : base(messageProvider)
        {
        }
    }
}
