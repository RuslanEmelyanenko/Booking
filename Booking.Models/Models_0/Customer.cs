namespace Booking.Models.Models_0
{
    public class Customer : Entity
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string PhoneNuimber { get; set; }
        public string Email { get; set; }
        public string? Instagrams { get; set; }
        public string? Facebooks { get; set; }
        public string? Telegrams { get; set; }
        public List<BookingConfirmation> BookingConfirmations { get; set; }
    }
}