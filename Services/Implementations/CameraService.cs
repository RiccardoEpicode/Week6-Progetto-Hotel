using HotelReservationApp.Data;
using HotelReservationApp.Models.Entities;
using HotelReservationApp.Services.Interfaces;

namespace HotelReservationApp.Services.Implementations
{
    public class CameraService : ICameraService
    {
        private readonly AppDbContext _db;
        public CameraService(AppDbContext db) { _db = db; }

        public List<Camera> GetAll() => _db.Camere.ToList();
        public Camera? GetById(int id) => _db.Camere.Find(id);

        public void Add(Camera c)
        {
            _db.Camere.Add(c);
            _db.SaveChanges();
        }

        public void Update(Camera c)
        {
            _db.Camere.Update(c);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var c = _db.Camere.Find(id);
            if (c != null)
            {
                _db.Camere.Remove(c);
                _db.SaveChanges();
            }
        }
    }
}
