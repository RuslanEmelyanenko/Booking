namespace Booking.Models.Models_0
{
    public class BookingConfirmation : Entity
    {
        public DateTime BookingDate { get; set; }
        public int AppartmentId { get; set; }
        public Appartment Appartment { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public bool IsApproved { get; set; }
    }
}