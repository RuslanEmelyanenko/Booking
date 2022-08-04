using System.Collections.Generic;

namespace Booking.Models
{
    public partial class District : Entity
    {
        public string DistrictName { get; set; } = string.Empty;
        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}