using CQRSDEMO.CQRS.Validation;
using CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer;
using CQRSDEMO.Modules.Customer.Query.Customer.GetCustomerById;
using FluentValidation;

namespace CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer
{
    public class GetCustomerByIdQueryValidator : Validator<GetCustomerByIdQuery>
    {
        public GetCustomerByIdQueryValidator(IValidationMessageProvider messageProvider) : base(messageProvider)
        {
        }
    }
}
