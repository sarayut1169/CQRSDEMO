using CQRSDEMO.Models.APIs;
using CQRSDEMO.Models.Entities;
using CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer;
using CQRSDEMO.Modules.Customer.Services;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;

namespace CQRSDEMO.Modules.Customer.Commands.Update
{
    public class UpdateCustomerCommandHandler : CQRS.Queries.QueryHandler<UpdateCustomerCommand, UpdateCustomerCommandResult, List<UpdateCustomerCommandResultData>>
    {
        private readonly ICustomerService _customerService;

        public UpdateCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        protected override async Task<UpdateCustomerCommandResult> OnExecute(UpdateCustomerCommand query, CancellationToken cancellationToken)
        {
            UpdateCustomerCommandResult result = new UpdateCustomerCommandResult();

            try
            {
                CustomerModel customer = await _customerService.GetCustomerByIdAsync(query.Id);
                customer.IdCardNumber = query.IdCardNumber;
                customer.Name = query.Name;
                customer.Email = query.Email;
                customer.Phone = query.Phone;
                customer.MembershipType = query.MembershipType;
                customer.IsGoldShop = query.IsGoldShop;
                customer.CurrentAddress = query.CurrentAddress;
                customer.DocumentAddress = query.DocumentAddress;


                CustomerModel updateCustomer = await _customerService.UpdateCustomerAsync(customer);

                var resultItem = new UpdateCustomerCommandResultData
                {
                    Id = updateCustomer.Id,
                    Name = updateCustomer.Name,
                    Email = updateCustomer.Email,
                    Phone = updateCustomer.Phone,
                    MembershipType = updateCustomer.MembershipType,
                    IsGoldShop = updateCustomer.IsGoldShop,
                    IdCardNumber = updateCustomer.IdCardNumber,
                    CurrentAddress = updateCustomer.CurrentAddress,
                    DocumentAddress = updateCustomer.DocumentAddress
                };

                result.ResultData = new List<UpdateCustomerCommandResultData> { resultItem };
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
