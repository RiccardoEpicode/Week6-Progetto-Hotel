using Booking.com.Models.Entities;

namespace Booking.com.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> RegisterUserAsync(
            string email,
            string password,
            string firstName,
            string lastName,
            string phoneNumber);

        Task<ApplicationUser?> GetCurrentUserAsync(string username);
    }
}
