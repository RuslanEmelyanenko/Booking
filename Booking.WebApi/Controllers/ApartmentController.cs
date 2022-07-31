using Booking.Dtos.BaseDTOs;
using Booking.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Booking.WebApi.Controllers
{
    [ApiController]
    [Route("api/apartment")]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        // Get: Apartment
        [HttpGet]
        public async Task< ActionResult<IList<ApartmentDto>>> GatAllAsync()
        {
            var apartments = await _apartmentService.GatAllAsync();
            return Ok(apartments);
        }
    }
}
