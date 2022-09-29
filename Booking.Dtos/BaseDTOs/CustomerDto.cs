namespace Booking.Dtos.BaseDTOs
{
    public class CustomerDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? Telegram { get; set; }
    }
}