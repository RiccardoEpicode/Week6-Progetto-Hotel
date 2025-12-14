using Booking.com.Data;
using Booking.com.Models.Entities;
using Booking.com.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking.com.Services
{
    public class ReservationService : IReservationService
    {
        private readonly AppDbContext _context;

        public ReservationService(AppDbContext context)
        {
            _context = context;
        }

        public void Create(
            Guid roomId,
            Guid clientId,
            DateTime startDate,
            DateTime endDate)
        {
            var reservation = new Reservation
            {
                ReservationId = Guid.NewGuid(),
                RoomId = roomId,
                ClientId = clientId,
                StartDate = startDate,
                EndDate = endDate,
                IsConfirmed = false
            };

            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }

        public IEnumerable<Reservation> GetByClient(Guid clientId)
        {
            return _context.Reservations
                .Include(r => r.Room)
                .Where(r => r.ClientId == clientId)
                .ToList();
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _context.Reservations
                .Include(r => r.Room)
                .Include(r => r.Client)
                .ToList();
        }

        public void Confirm(Guid reservationId)
        {
            var r = _context.Reservations.Find(reservationId);
            if (r == null) return;

            r.IsConfirmed = true;
            _context.SaveChanges();
        }

        public void Delete(Guid reservationId)
        {
            var r = _context.Reservations.Find(reservationId);
            if (r == null) return;

            _context.Reservations.Remove(r);
            _context.SaveChanges();
        }
    }
}
