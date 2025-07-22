using CQRSDEMO.Models.APIs;

namespace CQRSDEMO.Modules.Customer.Services
{
    public interface ICustomerService
    {
       Task<List<CustomerModel>> GetAllCustomersAsync();

       Task<CustomerModel> GetCustomerByIdAsync(int id);

        Task<CustomerModel> CreateCustomerAsync(CustomerModel customerModel);
        Task<CustomerModel> UpdateCustomerAsync(CustomerModel customerModel);
        Task<bool> DeleteCustomerAsync(int id);
    }
}
