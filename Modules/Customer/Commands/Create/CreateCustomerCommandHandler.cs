using CQRSDEMO.Models.APIs;
using CQRSDEMO.Models.Entities;
using CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer;
using CQRSDEMO.Modules.Customer.Services;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;

namespace CQRSDEMO.Modules.Customer.Commands.Create
{
    public class CreateCustomerCommandHandler : CQRS.Queries.QueryHandler<CreateCustomerCommand, CreateCustomerCommandResult, List<CreateCustomerCommandResultData>>
    {
        private readonly ICustomerService _customerService;

        public CreateCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        protected override async Task<CreateCustomerCommandResult> OnExecute(CreateCustomerCommand query, CancellationToken cancellationToken)
        {
            CreateCustomerCommandResult result = new CreateCustomerCommandResult();

            try
            {
                CustomerModel customerModel = new CustomerModel
                {
                    Name = query.Name,
                    Email = query.Email,
                    Phone = query.Phone,
                    MembershipType = query.MembershipType,
                    IsGoldShop = query.IsGoldShop,
                    IdCardNumber = query.IdCardNumber,
                    CurrentAddress = query.CurrentAddress,
                    DocumentAddress = query.DocumentAddress
                };

                CustomerModel createdCustomer = await _customerService.CreateCustomerAsync(customerModel);

                var resultItem = new CreateCustomerCommandResultData
                {
                    Id = createdCustomer.Id,
                    Name = createdCustomer.Name,
                    Email = createdCustomer.Email,
                    Phone = createdCustomer.Phone,
                    MembershipType = createdCustomer.MembershipType,
                    IsGoldShop = createdCustomer.IsGoldShop,
                    IdCardNumber = createdCustomer.IdCardNumber,
                    CurrentAddress = createdCustomer.CurrentAddress,
                    DocumentAddress = createdCustomer.DocumentAddress
                };

                result.ResultData = new List<CreateCustomerCommandResultData> { resultItem };
                result.IsSuccess = true;
                result.StatusCode = (int)HttpStatusCode.Created;
                result.Total = 1; // เนื่องจากสร้างลูกค้าเพียงคนเดียว
            }
            catch (Exception ex)
            {
                result.StatusCode = (int)HttpStatusCode.InternalServerError;
                result.IsSuccess = false;
                result.ErrorMessages = ex.Message;
            }

            return result;
        }


        
    }
}
