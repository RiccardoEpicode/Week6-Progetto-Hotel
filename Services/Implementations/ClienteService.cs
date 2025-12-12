using HotelReservationApp.Data;
using HotelReservationApp.Models.Entities;
using HotelReservationApp.Services.Interfaces;

namespace HotelReservationApp.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly AppDbContext _db;

        public ClienteService(AppDbContext db) { _db = db; }

        public List<Cliente> GetAll() => _db.Clienti.ToList();
        public Cliente? GetById(int id) => _db.Clienti.Find(id);

        public void Add(Cliente c)
        {
            _db.Clienti.Add(c);
            _db.SaveChanges();
        }

        public void Update(Cliente c)
        {
            _db.Clienti.Update(c);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var c = _db.Clienti.Find(id);
            if (c != null)
            {
                _db.Clienti.Remove(c);
                _db.SaveChanges();
            }
        }
    }
}
