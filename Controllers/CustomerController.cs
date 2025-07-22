using CQRSDEMO.Modules.Customer.Commands.Create;
using CQRSDEMO.Modules.Customer.Commands.Delete;
using CQRSDEMO.Modules.Customer.Commands.Update;
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
            if (!result.IsSuccess)
            {
                return NotFound(new { Message = "Customer not found." });
            }
            return Ok(result);
        }



        [HttpPost]
        [Route("add")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> AddCustomer([FromForm] CreateCustomerCommand input)
        {
            CreateCustomerCommand query = new CreateCustomerCommand()
            {

                Name = input.Name,
                Email = input.Email,
                Phone = input.Phone,
                MembershipType = input.MembershipType,
                IsGoldShop = input.IsGoldShop,
                IdCardNumber = input.IdCardNumber,
                CurrentAddress = input.CurrentAddress,
                DocumentAddress = input.DocumentAddress

            };

            CreateCustomerCommandResult createResult = await _mediator.Send(query);
            return Ok(createResult);
        }

        [HttpPut]
        [Route("update")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> UpdateCustomer([FromForm] UpdateCustomerCommand input)
        {
            UpdateCustomerCommand query = new UpdateCustomerCommand()
            {
                Id = input.Id,
                Name = input.Name,
                Email = input.Email,
                Phone = input.Phone,
                MembershipType = input.MembershipType,
                IsGoldShop = input.IsGoldShop,
                IdCardNumber = input.IdCardNumber,
                CurrentAddress = input.CurrentAddress,
                DocumentAddress = input.DocumentAddress
            };
            UpdateCustomerCommandResult updateResult = await _mediator.Send(query);
            return Ok(updateResult);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            DeleteCustomerCommand query = new DeleteCustomerCommand { Id = id };
            DeleteCustomerCommandResult deleteResult = await _mediator.Send(query);
            if (!deleteResult.IsSuccess)
            {
                return NotFound(new { Message = "Customer not found." });
            }
            return Ok(deleteResult);
        }
    }
}