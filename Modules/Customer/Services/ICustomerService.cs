using CQRSDEMO.Models.APIs;

namespace CQRSDEMO.Modules.Customer.Services
{
    public interface ICustomerService
    {
       Task<List<CustomerModel>> GetAllCustomersAsync();

       Task<CustomerModel> GetCustomerByIdAsync(int id);
    }
}
