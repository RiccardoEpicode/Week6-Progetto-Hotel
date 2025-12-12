using System.ComponentModel.DataAnnotations;

namespace HotelReservationApp.Models.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required]
        public string Nome { get; set; } = "";

        [Required]
        public string Cognome { get; set; } = "";

        [EmailAddress]
        public string Email { get; set; } = "";

        [Phone]
        public string Telefono { get; set; } = "";

        public List<Prenotazione> Prenotazioni { get; set; } = new();
    }
}
