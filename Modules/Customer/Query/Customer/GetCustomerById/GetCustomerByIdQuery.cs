using MediatR;
using CQRSDEMO.Models.APIs;
namespace CQRSDEMO.Modules.Customer.Query.Customer.GetCustomerById
{


    // ตัวอย่าง Query
    public class GetCustomerByIdQuery : IRequest<GetCustomerByIdQueryResult>
    {
      public int Id { get; set; }
    }

}
