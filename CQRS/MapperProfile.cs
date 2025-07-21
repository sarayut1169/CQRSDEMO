using AutoMapper;
using CQRSDEMO.Models.APIs;
using CQRSDEMO.Models.Entities;
using CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer;
using CQRSDEMO.Modules.Customer.Query.Customer.GetCustomerById;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerModel>();
        CreateMap<CustomerModel, Customer>();
        CreateMap<CustomerModel, GetCustomerByIdQueryResult>();
        CreateMap<GetCustomerByIdQueryResult, CustomerModel>();
    }
}
