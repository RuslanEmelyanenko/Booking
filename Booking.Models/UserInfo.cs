namespace Booking.Models
{
    public partial class UserInfo : Entity
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}