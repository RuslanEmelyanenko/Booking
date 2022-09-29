namespace Booking.Models
{
    public partial class Location : Entity
    {
        public Location()
        {
            Apartments = new HashSet<Apartment>();
        }

        public string Pleace { get; set; } = string.Empty;
        public int DistrictId { get; set; }

        public virtual District District { get; set; }
        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}