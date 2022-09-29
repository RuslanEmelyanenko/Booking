using Booking.Dtos.BaseDTOs;

namespace Booking.Services.Abstraction
{
    public interface IApartmentService
    {
        Task<ApartmentDto> GetAsync(string apartmentName);
        Task<IReadOnlyCollection<ApartmentDto>> GatAllAsync();
        Task<ApartmentDto> GetAsync(int id);
        Task DeleteItemAsync(string apartmentName);
        Task CreateItemAsync(ApartmentDto apartmentDto);
        Task UpdateAsync(ApartmentDto apartmentDto);
    }
}