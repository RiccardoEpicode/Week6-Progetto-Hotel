using Booking.com.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Booking.com.Data
{
    public static class InitialDataSeeding
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            var context = services.GetRequiredService<AppDbContext>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            // Applica migration
            await context.Database.MigrateAsync();

            // --------------------
            // ROLES
            // --------------------
            string[] roles = { "Admin", "Employee", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    var result = await roleManager.CreateAsync(new IdentityRole(role));
                    if (!result.Succeeded)
                        throw new Exception(string.Join(" | ",
                            result.Errors.Select(e => e.Description)));
                }
            }

            // --------------------
            // ADMIN USER (NO CLIENT)
            // --------------------
            string adminEmail = "admin@hotel.com";

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(admin, "Admin123!");

                if (!result.Succeeded)
                    throw new Exception(string.Join(" | ",
                        result.Errors.Select(e => e.Description)));

                await userManager.AddToRoleAsync(admin, "Admin");
            }

            // --------------------
            // ROOMS
            // --------------------
            if (!await context.Rooms.AnyAsync())
            {
                context.Rooms.AddRange(
                    new Room
                    {
                        RoomId = Guid.NewGuid(),
                        RoomNumber = 101,
                        Type = "Single",
                        Price = 80
                    },
                    new Room
                    {
                        RoomId = Guid.NewGuid(),
                        RoomNumber = 102,
                        Type = "Double",
                        Price = 120
                    },
                    new Room
                    {
                        RoomId = Guid.NewGuid(),
                        RoomNumber = 201,
                        Type = "Suite",
                        Price = 250
                    }
                );

                await context.SaveChangesAsync();
            }
        }
    }
}
