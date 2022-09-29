using Booking.Dtos.BaseDTOs;
using Booking.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Booking.WebApi.Controllers
{
    [ApiController]
    [Route("api/districts")]
    public class DistrictController : ControllerBase 
    {
        private readonly IDistrictService _districtService;

        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        // GetAll: Districts
        [HttpGet]
        public async Task<ActionResult<IList<DistrictDto>>> GetAllAsync()
        {
            var districts = await _districtService.GatAllAsync();

            return Ok(districts);
        }

        // Get: District
        [HttpGet("id")]
        public async Task<ActionResult<DistrictDto>> GetAsync(int id)
        {
            var district = await _districtService.GetAsync(id);

            if (district == null)
            {
                return BadRequest();
            }

            return Ok(district);
        }

        // Delete: District
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var district = await _districtService.GetAsync(id);

            if(district == null)
            {
                return BadRequest();
            }

            await _districtService.DeleteItemAsync(id);

            return Ok(new { Message = "Deleted successfally!" });
        }
    }
}
