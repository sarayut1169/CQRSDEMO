using AutoMapper;
using CQRSDEMO.Models.APIs;
using CQRSDEMO.Models.Repositories.Customer;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CQRSDEMO.Modules.Customer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
      
        private readonly IMapper _mapper;

        public CustomerService(
            ICustomerRepository customerRepository,
      
            IMapper mapper
        )
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }



        public async Task<List<CustomerModel>> GetAllCustomersAsync()
        {
            IEnumerable<CQRSDEMO.Models.Entities.Customer> customers = await _customerRepository.GetAllAsync();

            List<CustomerModel> customerModels = _mapper.Map<List<CustomerModel>>(customers);

            return customerModels;

        }

        public async Task<CustomerModel> GetCustomerByIdAsync(int id)
        {
            CQRSDEMO.Models.Entities.Customer customer = await _customerRepository.GetAsync(x => x.Id == id);
            if (customer == null)
            {
                return null;
            }
            CustomerModel customerModel = _mapper.Map<CustomerModel>(customer);
            return customerModel;
        }

        public async Task<CustomerModel> CreateCustomerAsync(CustomerModel customerModel)
        {
            CQRSDEMO.Models.Entities.Customer customer = _mapper.Map<CQRSDEMO.Models.Entities.Customer>(customerModel);
            CQRSDEMO.Models.Entities.Customer createdCustomer = await _customerRepository.AddAsync(customer);
            return _mapper.Map<CustomerModel>(createdCustomer);
        }


        public async Task<CustomerModel> UpdateCustomerAsync(CustomerModel customerModel)
        {
            CQRSDEMO.Models.Entities.Customer updatedCustomer = await _customerRepository.UpdateAsync(customerModel);
            CQRSDEMO.Models.Entities.Customer customer = _mapper.Map<CQRSDEMO.Models.Entities.Customer>(updatedCustomer);
            
            return _mapper.Map<CustomerModel>(updatedCustomer);
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            CQRSDEMO.Models.Entities.Customer customer = await _customerRepository.GetAsync(x => x.Id == id);
            if (customer == null)
            {
                return false;
            }
            _customerRepository.Delete(customer);
            return true;
        }
    }
}
