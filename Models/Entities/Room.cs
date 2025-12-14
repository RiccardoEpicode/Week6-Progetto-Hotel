namespace Booking.com.Models.Entities
{
    public class Room
    {
        public Guid RoomId { get; set; }
        public int RoomNumber { get; set; }
        public string Type { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
            = new List<Reservation>();
    }
}
