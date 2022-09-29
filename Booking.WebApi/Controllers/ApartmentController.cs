using Booking.Dtos.BaseDTOs;
using Booking.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Booking.WebApi.Controllers
{
    [ApiController]
    [Route("api/apartments")]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        // GetAll: Apartments
        [HttpGet]
        public async Task<ActionResult<IList<ApartmentDto>>> GatAllAsync()
        {
            var apartments = await _apartmentService.GatAllAsync();

            return Ok(apartments);
        }

        // Get: Apartment
        [HttpGet("{apartment}")]
        public async Task<ActionResult<ApartmentDto>> GetAsync(string apartment)
        {
            var apartmentName = await _apartmentService.GetAsync(apartment);

            if (apartmentName == null)
            {
                return BadRequest();
            }

            return Ok(apartmentName);
        }

        // Delete: Apartment
        [HttpDelete("{apartment}")]
        public async Task<ActionResult> DeleteItem(string apartment)
        {
            var apartmentName = await _apartmentService.GetAsync(apartment);

            if (apartmentName  == null)
            {
                return BadRequest();
            }

            await _apartmentService.DeleteItemAsync(apartment);

            return Ok(new { Message = "Deleted successfally!" });
        }

        // Post: Apartment
        [HttpPost]
        public async Task<ActionResult<ApartmentDto>> CreateItem(ApartmentDto apartmentDto)
        {
            await _apartmentService.CreateItemAsync(apartmentDto);

            return Ok(new { Message = "Create successfally!" });
        }

        // Put: Apartment
        [HttpPut]
        public async Task<ActionResult> UpdateAsync(ApartmentDto apartmentDto)
        {
            await _apartmentService.UpdateAsync(apartmentDto);

            return Ok(new { Message = "Update successfally!" });
        }
    }
}