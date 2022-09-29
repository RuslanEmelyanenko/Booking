using Booking.Dtos.BaseDTOs;
using Booking.Models;
using Booking.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Booking.WebApi.Controllers
{
    [ApiController]
    [Route("api/locations")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        // GetAll: Locations
        [HttpGet]
        public async Task<ActionResult<IList<LocationDto>>> GatAllAsync()
        {
            var locations = await _locationService.GatAllAsync();

            return Ok(locations);
        }

        // Get: Location
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDto>> GetAsync(int id)
        {
            var location = await _locationService.GetAsync(id);

            if (location == null)
            {
                return BadRequest();
            }

            return Ok(location);
        }

        // Delete: Location
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var location = await _locationService.GetAsync(id);

            if(location == null)
            {
                return BadRequest();
            }

            await _locationService.DeleteItemAsync(id);

            return Ok(new { Message = "Deleted successfally!" });
        }
    }
}
