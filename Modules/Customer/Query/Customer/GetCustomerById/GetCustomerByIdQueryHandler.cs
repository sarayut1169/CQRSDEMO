using CQRSDEMO.Models.APIs;
using CQRSDEMO.Models.Entities;
using CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer;
using CQRSDEMO.Modules.Customer.Services;
using System.Collections.Generic;

namespace CQRSDEMO.Modules.Customer.Query.Customer.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : MediatR.IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdQueryResult>
    {
        private readonly ICustomerService _customerService;

        public GetCustomerByIdQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }



        public async Task<GetCustomerByIdQueryResult> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerService.GetCustomerByIdAsync(request.Id);

            return new GetCustomerByIdQueryResult
            {
                Customers = new List<GetCustomerByIdQueryResultData>
                {
                    new GetCustomerByIdQueryResultData
                    {
                        Id = customer.Id,
                        Name = customer.Name,
                        Email = customer.Email,
                        Phone = customer.Phone,
                        MembershipType = customer.MembershipType,
                        IsGoldShop = customer.IsGoldShop,
                        IdCardNumber = customer.IdCardNumber,
                        Address = customer.Address,
                        CurrentAddress = customer.CurrentAddress,
                        DocumentAddress = customer.DocumentAddress
                    }
                }
            };
        }
    }   
}
