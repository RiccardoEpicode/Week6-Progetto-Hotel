namespace HotelReservationApp.Models.Entities
{
    public class Prenotazione
    {
        public int PrenotazioneId { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public int CameraId { get; set; }
        public Camera Camera { get; set; } = null!;

        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }

        public string Stato { get; set; } = "In Attesa";
    }
}
