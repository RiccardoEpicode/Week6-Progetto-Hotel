using Booking.com.Data;
using Booking.com.Models.Entities;
using Booking.com.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Booking.com.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;

        public UserService(
            UserManager<ApplicationUser> userManager,
            AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<ApplicationUser> RegisterUserAsync(
            string email,
            string password,
            string firstName,
            string lastName,
            string phoneNumber)
        {
            // 1️⃣ creo Client
            var client = new Client
            {
                ClientId = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            // 2️⃣ creo ApplicationUser
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                ClientId = client.ClientId
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                throw new Exception(string.Join(" | ",
                    result.Errors.Select(e => e.Description)));

            // 3️⃣ assegno ruolo User
            await _userManager.AddToRoleAsync(user, "User");

            return user;
        }

        public async Task<ApplicationUser?> GetCurrentUserAsync(string username)
        {
            return await _userManager.Users
                .Include(u => u.Client)
                .FirstOrDefaultAsync(u => u.UserName == username);
        }
    }
}
