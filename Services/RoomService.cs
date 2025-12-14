using Booking.com.Data;
using Booking.com.Models.Entities;
using Booking.com.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking.com.Services
{
    public class RoomService : IRoomService
    {
        private readonly AppDbContext _context;

        public RoomService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Room> GetAll()
        {
            return _context.Rooms.ToList();
        }

        public Room GetById(Guid id)
        {
            return _context.Rooms.Find(id);
        }

        public void Create(Room room)
        {
            room.RoomId = Guid.NewGuid();
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var room = _context.Rooms.Find(id);
            if (room == null) return;

            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }

    }
}
