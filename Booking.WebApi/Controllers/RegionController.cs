using Booking.Dtos.BaseDTOs;
using Booking.Models;
using Booking.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Booking.WebApi.Controllers
{
    [ApiController]
    [Route("api/regions")]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        // GetAll: Regions
        [HttpGet]
        public async Task<ActionResult<IList<RegionDto>>> GetAll()
        {
            var regions = await _regionService.GatAllAsync();

            return Ok(regions);
        }

        // Get: Region
        [HttpGet("{id}")]
        public async Task<ActionResult<RegionDto>> GetAsync(int id)
        {
            var region = await _regionService.GetAsync(id);

            if (region == null)
            {
                return BadRequest();
            }

            return Ok(region);
        }

        // Delete: Region
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            RegionDto region = await _regionService.GetAsync(id);

            if (region == null)
            {
                return BadRequest();
            }

            await _regionService.DeleteItemAsync(id);

            return Ok(new { Message = "Deleted successfally!" });
        }
    }
}