using Booking.Dtos.BaseDTOs;

namespace Booking.Services.Abstraction
{
    public interface IRegionService
    {
        Task<RegionDto> GetAsync(string entity);
        Task<IReadOnlyCollection<RegionDto>> GatAllAsync();
        Task<RegionDto> GetAsync(int id);
        Task DeleteItemAsync(int id);
    }
}