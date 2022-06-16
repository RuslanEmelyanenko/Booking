namespace Booking.Models.Models_0
{
    public class Location : Entity
    {
        public string LocationName { get; set; }
        public string? MicroDistrict { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
        public List<Appartment> Appartments { get; set; }
    }
}