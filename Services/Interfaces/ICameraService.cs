using HotelReservationApp.Models.Entities;

namespace HotelReservationApp.Services.Interfaces
{
    public interface ICameraService
    {
        List<Camera> GetAll();
        Camera? GetById(int id);
        void Add(Camera c);
        void Update(Camera c);
        void Delete(int id);
    }
}
