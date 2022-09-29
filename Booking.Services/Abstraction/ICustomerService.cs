using Booking.Dtos.BaseDTOs;

namespace Booking.Services.Abstraction
{
    public interface ICustomerService
    {
        Task<IReadOnlyCollection<CustomerDto>> GatAllAsync();
        Task<CustomerDto> GetAsync(int id);
        Task DeleteItemAsync(int id);
        Task CreateItemAsync(CustomerDto customerDto);
        Task UpdateAsync(CustomerDto customerDto);
    }
}