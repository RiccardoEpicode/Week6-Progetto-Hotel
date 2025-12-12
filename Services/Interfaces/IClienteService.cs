using HotelReservationApp.Models.Entities;

namespace HotelReservationApp.Services.Interfaces
{
    public interface IClienteService
    {
        List<Cliente> GetAll();
        Cliente? GetById(int id);
        void Add(Cliente c);
        void Update(Cliente c);
        void Delete(int id);
    }
}
