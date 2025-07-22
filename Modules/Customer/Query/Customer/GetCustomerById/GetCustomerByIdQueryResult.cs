using CQRSDEMO.Models.APIs;
using CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer;

namespace CQRSDEMO.Modules.Customer.Query.Customer.GetCustomerById
{



    public class GetCustomerByIdQueryResult : CQRS.Queries.QueryResult<List<GetCustomerByIdQueryResultData>>
    {
        public GetCustomerByIdQueryResultData ResultData { get; set; }
    }
}