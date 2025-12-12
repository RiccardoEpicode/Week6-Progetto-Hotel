using HotelReservationApp.Models;
using Microsoft.AspNetCore.Identity;

namespace HotelReservationApp.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles = { "Admin", "Manager", "Viewer" };

            foreach (var r in roles)
                if (!await roleManager.RoleExistsAsync(r))
                    await roleManager.CreateAsync(new ApplicationRole { Name = r });

            // CREATE ADMIN
            var admin = await userManager.FindByEmailAsync("admin@hotel.com");

            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = "admin@hotel.com",
                    Email = "admin@hotel.com",
                    FullName = "Hotel Admin"
                };

                await userManager.CreateAsync(admin, "Admin123!");
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
