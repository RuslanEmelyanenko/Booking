using Booking.Dtos.BaseDTOs;
using Booking.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Booking.WebApi.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        // GetAll: Countries
        [HttpGet]
        public async Task<ActionResult<IList<CountryDto>>> GatAllAsync()
        {
            var countries = await _countryService.GatAllAsync();

            return Ok(countries);
        }

        // Get: Country
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetAsync(int id)
        {
            var country = await _countryService.GetAsync(id);

            if (country == null)
            {
                return BadRequest();
            }

            return Ok(country);
        }

        // Delete: Country
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var country = await _countryService.GetAsync(id);

            if(country == null)
            {
                return BadRequest(country);
            }

            await _countryService.DeleteItemAsync(id);

            return Ok(new { Message = "Deleted successfally!" });
        }
    }
}