using Booking.Dtos.BaseDTOs;
using Booking.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Booking.WebApi.Controllers
{
    [ApiController]
    [Route("api/bookingConfirmations")]
    public class BookingConfirmationController : ControllerBase
    {
        private readonly IBookingConfirmationService _confirmationService;

        public BookingConfirmationController(IBookingConfirmationService confirmationService)
        {
            _confirmationService = confirmationService;
        }

        // GetAll: BookingConfirmations
        [HttpGet]
        public async Task<ActionResult<IList<BookingConfirmationDto>>> GetAllAsync()
        {
            var bookingConfirmations = await _confirmationService.GatAllAsync();

            return Ok(bookingConfirmations);
        }

        // Get: BookingConfirmations
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingConfirmationDto>> GetAsync(int id)
        {
            var bookingConfirmation = await _confirmationService.GetAsync(id);

            if (bookingConfirmation == null)
            {
                return BadRequest();
            }

            return Ok(bookingConfirmation);
        }

        // Delete: BookingConfirmation
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var bookingConfirmations = await _confirmationService.GetAsync(id);

            if (bookingConfirmations == null)
            {
                return BadRequest();
            }

            await _confirmationService.DeleteItemAsync(id);

            return Ok(new { Message = "Deleted successfally!" });
        }

        // Post: BookingConfirmation
        [HttpPost]
        public async Task<ActionResult<BookingConfirmationDto>> CreateItem(BookingConfirmationDto bookingConfirmationDto)
        {
            await _confirmationService.CreateItemAsync(bookingConfirmationDto);

            return Ok(new { Message = "Create successfally!" });
        }

        // Put: BookingConfirmation
        [HttpPut]
        public async Task<ActionResult> UpdateAsync(BookingConfirmationDto bookingConfirmationDto)
        {
            await _confirmationService.UpdateAsync(bookingConfirmationDto);

            return Ok(new { Message = "Update successfally!" });
        }
    }
}