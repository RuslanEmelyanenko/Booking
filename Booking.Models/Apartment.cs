namespace Booking.Models
{
    public partial class Apartment : Entity
    {
        public Apartment()
        {
            BookingConfirmations = new HashSet<BookingConfirmation>();
        }

        public string ApartmentName { get; set; } = string.Empty;
        public int LocationId { get; set; }
        public string? PhotoAppartment { get; set; }
        public string? Reviews { get; set; }
        public double? Gpa { get; set; }

        public virtual Location Location { get; set; } = null!;
        public virtual ICollection<BookingConfirmation> BookingConfirmations { get; set; }
    }
}