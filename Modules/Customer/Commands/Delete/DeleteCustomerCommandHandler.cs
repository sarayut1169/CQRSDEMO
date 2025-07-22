using CQRSDEMO.Models.APIs;
using CQRSDEMO.Models.Entities;
using CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer;
using CQRSDEMO.Modules.Customer.Services;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;

namespace CQRSDEMO.Modules.Customer.Commands.Delete
{
    public class DeleteCustomerCommandHandler : CQRS.Queries.QueryHandler<DeleteCustomerCommand, DeleteCustomerCommandResult, List<DeleteCustomerCommandResultData>>
    {
        private readonly ICustomerService _customerService;

        public DeleteCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        protected override async Task<DeleteCustomerCommandResult> OnExecute(DeleteCustomerCommand query, CancellationToken cancellationToken)
        {
            DeleteCustomerCommandResult result = new DeleteCustomerCommandResult();

            try
            {




                bool isDeleted = await _customerService.DeleteCustomerAsync(query.Id);

                if (!isDeleted)
                {
                    return new DeleteCustomerCommandResult
                    {
                        IsSuccess = false,
                       
                    };
                }
               
                result.IsSuccess = true;
                result.StatusCode = 200; // HTTP Status Code 200 OK
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
