using Booking.Dtos.BaseDTOs;
using Booking.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Booking.WebApi.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GetAll: Customers
        [HttpGet]
        public async Task<ActionResult<IList<CustomerDto>>> GatAllAsync()
        {
            var customers = await _customerService.GatAllAsync();

            return Ok(customers);
        }

        // Get: Customer
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetAsync(int id)
        {
            var customer = await _customerService.GetAsync(id);

            if (customer == null)
            {
                return BadRequest();
            }

            return Ok(customer);
        }

        // Delete: Customer
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(int id)
        {
            var customer = await _customerService.GetAsync(id);

            if(customer == null)
            {
                return BadRequest();
            }

            await _customerService.DeleteItemAsync(id);

            return Ok(new { Message = "Deleted successfally!" });
        }

        // Post: Customer
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateItemAsync(CustomerDto customerDto)
        {
            await _customerService.CreateItemAsync(customerDto);

            return Ok(new { Message = "Create successfally!" });
        }

        // Put: Customer
        [HttpPut]
        public async Task<ActionResult> UpdateAsync(CustomerDto customerDto)
        {
            await _customerService.UpdateAsync(customerDto);

            return Ok(new { Message = "Update successfally!" });
        }
    }
}