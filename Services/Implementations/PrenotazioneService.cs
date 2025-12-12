using HotelReservationApp.Data;
using HotelReservationApp.Models.Entities;
using HotelReservationApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationApp.Services.Implementations
{
    public class PrenotazioneService : IPrenotazioneService
    {
        private readonly AppDbContext _db;

        public PrenotazioneService(AppDbContext db)
        {
            _db = db;
        }

        public List<Prenotazione> GetAll() =>
            _db.Prenotazioni.Include(p => p.Cliente).Include(p => p.Camera).ToList();

        public Prenotazione? GetById(int id) =>
            _db.Prenotazioni.Include(p => p.Cliente).Include(p => p.Camera)
                .FirstOrDefault(p => p.PrenotazioneId == id);

        public void Add(Prenotazione p)
        {
            _db.Prenotazioni.Add(p);
            _db.SaveChanges();
        }

        public void Update(Prenotazione p)
        {
            _db.Prenotazioni.Update(p);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var p = _db.Prenotazioni.Find(id);
            if (p != null)
            {
                _db.Prenotazioni.Remove(p);
                _db.SaveChanges();
            }
        }
    }
}
