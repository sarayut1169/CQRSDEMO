using CQRSDEMO.Models.APIs;
using CQRSDEMO.Models.Entities;
using CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer;
using CQRSDEMO.Modules.Customer.Services;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer
{
    public class GetCustomerQueryHandler : CQRS.Queries.QueryHandler<GetCustomerQuery, GetCustomerQueryResult, List<GetCustomerQueryResultData>>
    {
        private readonly ICustomerService _customerService;

        public GetCustomerQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }



        protected override async Task<GetCustomerQueryResult> OnExecute(GetCustomerQuery query, CancellationToken cancellationToken)
        {
            GetCustomerQueryResult result = new GetCustomerQueryResult();

            List<CustomerModel>? customerList = await _customerService.GetAllCustomersAsync();

            List<GetCustomerQueryResultData> customerModels = customerList.Select(x =>
            {
                GetCustomerQueryResultData getCustomerQuery = new GetCustomerQueryResultData
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    MembershipType = x.MembershipType,
                    IsGoldShop = x.IsGoldShop,
                    IdCardNumber = x.IdCardNumber,
                    CurrentAddress = x.CurrentAddress,
                    DocumentAddress = x.DocumentAddress,
                };
                return getCustomerQuery;
            }).ToList();

            result.IsSuccess = true;
            result.ResultData = customerModels;
            result.Total = customerModels.Count;

            return result;
        }
    }   
}
