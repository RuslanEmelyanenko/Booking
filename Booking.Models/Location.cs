namespace Booking.Models
{
    public partial class Location : Entity
    {
        public Location()
        {
            Appartments = new HashSet<Appartment>();
        }

        public string Pleace { get; set; } = null!;
        public int DistrictId { get; set; }

        public virtual District District { get; set; } = null!;
        public virtual ICollection<Appartment> Appartments { get; set; }
    }
}