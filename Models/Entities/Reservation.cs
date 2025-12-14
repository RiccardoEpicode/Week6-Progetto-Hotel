namespace Booking.com.Models.Entities
{
    public class Reservation
    {
        public Guid ReservationId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsConfirmed { get; set; }

        // FK Client
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        // FK Room
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
    }
}
