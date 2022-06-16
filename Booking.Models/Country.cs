namespace Booking.Models
{
    public partial class Country : Entity
    {
        public Country()
        {
            Regions = new HashSet<Region>();
        }

        public string CountryName { get; set; } = null!;

        public virtual ICollection<Region> Regions { get; set; }
    }
}