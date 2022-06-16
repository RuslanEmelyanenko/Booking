namespace Booking.Models.Models_0
{
    public class Appartment : Entity
    {
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public string? PhotoAppartment { get; set; }
        public string? Reviews { get; set; }
        public float? GPA { get; set; }
        public List<BookingConfirmation> BookingConfirmations { get; set; }
    }
}