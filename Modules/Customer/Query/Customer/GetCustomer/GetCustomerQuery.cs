using CQRSDEMO.CQRS.Queries;
using CQRSDEMO.CQRS.Validation;
using CQRSDEMO.Models.APIs;
using FluentValidation;
using MediatR;
namespace CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer
{


    // ตัวอย่าง Query
    public class GetCustomerQuery : Query<GetCustomerQueryResult, List<GetCustomerQueryResultData>>
    {
        
    }





}
