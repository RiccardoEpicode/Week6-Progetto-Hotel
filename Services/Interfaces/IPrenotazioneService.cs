using HotelReservationApp.Models.Entities;

namespace HotelReservationApp.Services.Interfaces
{
    public interface IPrenotazioneService
    {
        List<Prenotazione> GetAll();
        Prenotazione? GetById(int id);
        void Add(Prenotazione p);
        void Update(Prenotazione p);
        void Delete(int id);
    }
}
