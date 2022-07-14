namespace Booking.Dtos.BaseDTOs
{
    public class BookingConfirmationDto
    {
        public DateTime BookingDate { get; set; }
        public string ApartmentName { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerSurname { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string IsApproved { get; set; } = string.Empty;
    }
}