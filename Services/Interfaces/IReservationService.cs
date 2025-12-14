using Booking.com.Models.Entities;

namespace Booking.com.Services.Interfaces
{
    public interface IReservationService
    {
        void Create(
            Guid roomId,
            Guid clientId,
            DateTime startDate,
            DateTime endDate);

        IEnumerable<Reservation> GetByClient(Guid clientId);

        IEnumerable<Reservation> GetAll();
        void Confirm(Guid reservationId);
        void Delete(Guid reservationId);
    }
}
