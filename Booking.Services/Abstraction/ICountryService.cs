using Booking.Dtos.BaseDTOs;

namespace Booking.Services.Abstraction
{
    public interface ICountryService
    {
        Task<CountryDto> GetAsync(string countryName);
        Task<IReadOnlyCollection<CountryDto>> GatAllAsync();
        Task<CountryDto> GetAsync(int id);
        Task DeleteItemAsync(int id);
    }
}