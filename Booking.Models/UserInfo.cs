namespace Booking.Models
{
    public partial class UserInfo : Entity
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}