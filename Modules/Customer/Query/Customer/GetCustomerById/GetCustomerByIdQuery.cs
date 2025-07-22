using CQRSDEMO.CQRS.Queries;
using CQRSDEMO.Models.APIs;
using CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer;
using MediatR;
namespace CQRSDEMO.Modules.Customer.Query.Customer.GetCustomerById
{


    // ตัวอย่าง Query




    public class GetCustomerByIdQuery : Query<GetCustomerByIdQueryResult, List<GetCustomerByIdQueryResultData>>
    {
        public int Id { get; set; }
    }
}
