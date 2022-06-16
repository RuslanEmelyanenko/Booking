namespace Booking.Models.Models_0
{
    public class Region : Entity
    {
        public string? RegionName { get; set; }
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        public List<District>? Districts { get; set; }
    }
}