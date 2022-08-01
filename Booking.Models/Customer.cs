using System.Collections.Generic;

namespace Booking.Models
{
    public partial class Customer : Entity
    {
        public Customer()
        {
            BookingConfirmations = new HashSet<BookingConfirmation>();
        }

        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? Telegram { get; set; }

        public virtual ICollection<BookingConfirmation> BookingConfirmations { get; set; }
    }
}