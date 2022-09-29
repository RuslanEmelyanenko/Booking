using Booking.Dtos.BaseDTOs;

namespace Booking.Services.Abstraction
{
    public interface IDistrictService
    {
        Task<DistrictDto> GetAsync(string entity);
        Task<IReadOnlyCollection<DistrictDto>> GatAllAsync();
        Task<DistrictDto> GetAsync(int id);
        Task DeleteItemAsync(int id);
    }
}