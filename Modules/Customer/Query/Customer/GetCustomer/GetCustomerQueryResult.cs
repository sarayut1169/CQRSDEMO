using CQRSDEMO.Models.APIs;

namespace CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer
{
    public class GetCustomerQueryResult
    {
        public List<GetCustomerQueryResultData> Customers { get; set; } = new();
    }
}
    