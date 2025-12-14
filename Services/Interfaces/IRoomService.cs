using Booking.com.Models.Entities;

namespace Booking.com.Services.Interfaces
{
    public interface IRoomService
    {
        IEnumerable<Room> GetAll();
        Room GetById(Guid id);
        void Create(Room room);
        void Delete(Guid id);

    }
}
