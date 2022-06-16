namespace Booking.Models
{
    public partial class District : Entity
    {
        public District()
        {
            Locations = new HashSet<Location>();
        }

        public string DistrictName { get; set; } = null!;
        public int RegionId { get; set; }

        public virtual Region Region { get; set; } = null!;
        public virtual ICollection<Location> Locations { get; set; }
    }
}