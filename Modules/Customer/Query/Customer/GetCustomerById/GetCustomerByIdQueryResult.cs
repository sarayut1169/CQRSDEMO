using CQRSDEMO.Models.APIs;

namespace CQRSDEMO.Modules.Customer.Query.Customer.GetCustomerById
{
    public class GetCustomerByIdQueryResult
    {
        public List<GetCustomerByIdQueryResultData> Customers { get; set; } = new();
    }
}
    