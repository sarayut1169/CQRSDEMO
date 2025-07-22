using CQRSDEMO.CQRS.Queries;
using CQRSDEMO.CQRS.Validation;
using CQRSDEMO.Models.APIs;
using FluentValidation;
using MediatR;
using static CQRSDEMO.Models.APIs.CustomerModel;
namespace CQRSDEMO.Modules.Customer.Commands.Delete
{


    // ตัวอย่าง Query
    public class DeleteCustomerCommand : Query<DeleteCustomerCommandResult, List<DeleteCustomerCommandResultData>>
    {
        public int Id { get; set; }


    
    }





}
