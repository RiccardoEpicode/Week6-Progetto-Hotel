using System.ComponentModel.DataAnnotations;

namespace HotelReservationApp.Models.Entities
{
    public class Camera
    {
        public int CameraId { get; set; }
        public int Numero { get; set; }
        public string Tipo { get; set; } = "";
        public decimal Prezzo { get; set; }
        public List<Prenotazione> Prenotazioni { get; set; } = new();
    }
}
