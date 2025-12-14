using Microsoft.AspNetCore.Identity;

namespace Booking.com.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        // FK verso Client
        public Guid? ClientId { get; set; }
        public Client Client { get; set; }
    }
}
