using System.ComponentModel.DataAnnotations;

namespace Booking.com.Models.Entities
{
    public class Client
    {
        public Guid ClientId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
