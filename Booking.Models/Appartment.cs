namespace Booking.Models
{
    public partial class Appartment : Entity
    {
        public Appartment()
        {
            BookingConfirmations = new HashSet<BookingConfirmation>();
        }

        public int LocationId { get; set; }
        public string? PhotoAppartment { get; set; }
        public string? Reviews { get; set; }
        public double? Gpa { get; set; }

        public virtual Location Location { get; set; } = null!;
        public virtual ICollection<BookingConfirmation> BookingConfirmations { get; set; }
    }
}