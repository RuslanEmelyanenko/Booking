using Booking.Dtos.BaseDTOs;

namespace Booking.Services.Abstraction
{
    public interface IBookingConfirmationService
    {
        Task<BookingConfirmationDto> GetAsync(string entity);
        Task<IReadOnlyCollection<BookingConfirmationDto>> GatAllAsync();
        Task<BookingConfirmationDto> GetAsync(int id);
        Task DeleteItemAsync(int id);
        Task CreateItemAsync(BookingConfirmationDto bookingConfirmationDto);
        Task UpdateAsync(BookingConfirmationDto bookingConfirmationDto);
    }
}