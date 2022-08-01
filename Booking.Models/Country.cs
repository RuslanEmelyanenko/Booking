using System.Collections.Generic;

namespace Booking.Models
{
    public partial class Country : Entity
    {
        public Country()
        {
            Regions = new HashSet<Region>();
        }

        public string CountryName { get; set; } = string.Empty;

        public virtual ICollection<Region> Regions { get; set; }
    }
}