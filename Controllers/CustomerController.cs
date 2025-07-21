using CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer;
using CQRSDEMO.Modules.Customer.Query.Customer.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDEMO.Controllers
{
    [Tags("Customer")]
    [Route("api/Customer/")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAll()
        {
            GetCustomerQuery query = new GetCustomerQuery();

            GetCustomerQueryResult result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetCustomerByIdQuery query = new GetCustomerByIdQuery { Id = id };
            GetCustomerByIdQueryResult result = await _mediator.Send(query);
            if (result.Customers.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}