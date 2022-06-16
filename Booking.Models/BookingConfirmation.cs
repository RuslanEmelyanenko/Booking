namespace Booking.Models
{
    public partial class BookingConfirmation : Entity
    {
        public DateTime BookingDate { get; set; }
        public int AppartmentId { get; set; }
        public int CustomerId { get; set; }
        public string IsApproved { get; set; } = null!;

        public virtual Appartment Appartment { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
    }
}