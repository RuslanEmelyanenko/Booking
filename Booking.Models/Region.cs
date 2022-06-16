namespace Booking.Models
{
    public partial class Region : Entity
    {
        public Region()
        {
            Districts = new HashSet<District>();
        }

        public string RegionName { get; set; } = null!;
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<District> Districts { get; set; }
    }
}