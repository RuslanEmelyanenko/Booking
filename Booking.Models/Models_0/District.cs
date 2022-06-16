namespace Booking.Models.Models_0
{
    public class District : Entity
    {
        public string DistrictName { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public List<Location> Locations { get; set; }
    }
}