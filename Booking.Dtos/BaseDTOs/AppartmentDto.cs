namespace Booking.Dtos.BaseDTOs
{
    public class AppartmentDto
    {
        public string AppartmentName { get; set; } = string.Empty;
        public string? PhotoAppartment { get; set; } = string.Empty;
        public string? Reviews { get; set; } = string.Empty;
        public double? GPA { get; set; }
    }
}