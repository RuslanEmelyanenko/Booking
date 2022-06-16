namespace Booking.Models.Models_0
{
    public class Country : Entity
    {
        public string CountryName { get; set; }
        public List<Region> Regions { get; set; }
    }
}