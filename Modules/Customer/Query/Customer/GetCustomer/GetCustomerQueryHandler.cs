using CQRSDEMO.Models.APIs;
using CQRSDEMO.Models.Entities;
using CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer;
using CQRSDEMO.Modules.Customer.Services;
using System.Collections.Generic;

namespace CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer
{
    public class GetCustomerQueryHandler : MediatR.IRequestHandler<GetCustomerQuery, GetCustomerQueryResult>
    {
        private readonly ICustomerService _customerService;

        public GetCustomerQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }



        public async Task<GetCustomerQueryResult> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customerList = await _customerService.GetAllCustomersAsync();

            var customerModels = customerList.Select(x => new GetCustomerQueryResultData
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone,
                MembershipType = x.MembershipType,
                IsGoldShop = x.IsGoldShop,
                IdCardNumber = x.IdCardNumber,
                Address = x.Address,
                CurrentAddress = x.CurrentAddress,
                DocumentAddress = x.DocumentAddress
            }).ToList();

            return new GetCustomerQueryResult
            {
                Customers = customerModels
            };
        }
    }   
}
