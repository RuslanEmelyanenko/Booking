using Booking.Dtos.BaseDTOs;

namespace Booking.Services.Abstraction
{
    public interface ILocationService
    {
        Task<LocationDto> GetAsync(string entity);
        Task<IReadOnlyCollection<LocationDto>> GatAllAsync();
        Task<LocationDto> GetAsync(int id);
        Task DeleteItemAsync(int id);
    }
}