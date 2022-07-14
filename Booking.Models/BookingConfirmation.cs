namespace Booking.Models
{
    public partial class BookingConfirmation : Entity
    {
        public DateTime BookingDate { get; set; }
        public int ApartmentId { get; set; }
        public int CustomerId { get; set; }
        public string IsApproved { get; set; } = string.Empty;

        public virtual Apartment Apartment { get; set; } 
        public virtual Customer Customer { get; set; } 
    }
}