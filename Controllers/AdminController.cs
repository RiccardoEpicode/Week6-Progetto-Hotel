using Booking.com.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Booking.com.Models.Entities;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IRoomService _roomService;
    private readonly IReservationService _reservationService;
    private readonly UserManager<ApplicationUser> _userManager;

    public AdminController(
        IRoomService roomService,
        IReservationService reservationService,
        UserManager<ApplicationUser> userManager)
    {
        _roomService = roomService;
        _reservationService = reservationService;
        _userManager = userManager;
    }

    // =========================
    // DASHBOARD
    // =========================
    public IActionResult Index()
    {
        return View();
    }

    // =========================
    // ROOMS
    // =========================
    public IActionResult Rooms()
    {
        return View(_roomService.GetAll());
    }

    [HttpGet]
    public IActionResult CreateRoom()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateRoom(Room room)
    {
        if (!ModelState.IsValid)
        {
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

            return View(room);
        }

        _roomService.Create(room);
        return RedirectToAction(nameof(Rooms));
    }


    public IActionResult DeleteRoom(Guid id)
    {
        _roomService.Delete(id);
        return RedirectToAction(nameof(Rooms));
    }

    // =========================
    // RESERVATIONS
    // =========================
    public IActionResult Reservations()
    {
        return View(_reservationService.GetAll());
    }

    public IActionResult ConfirmReservation(Guid id)
    {
        _reservationService.Confirm(id);
        return RedirectToAction(nameof(Reservations));
    }

    public IActionResult DeleteReservation(Guid id)
    {
        _reservationService.Delete(id);
        return RedirectToAction(nameof(Reservations));
    }

    // =========================
    // USERS
    // =========================
    public async Task<IActionResult> Users()
    {
        var users = await _userManager.Users
            .Include(u => u.Client)
            .ToListAsync();

        return View(users);
    }

    // =========================
    // EDIT USER (GET)
    // =========================
    [HttpGet]
    public async Task<IActionResult> EditUser(string id)
    {
        var user = await _userManager.Users
            .Include(u => u.Client)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
            return NotFound();

        // sicurezza: non editare admin seed
        if (user.Email == "admin@hotel.com")
            return RedirectToAction(nameof(Users));

        return View(user);
    }

    // =========================
    // EDIT USER (POST)
    // =========================
    [HttpPost]
    public async Task<IActionResult> EditUser(ApplicationUser model)
    {
        var user = await _userManager.Users
            .Include(u => u.Client)
            .FirstOrDefaultAsync(u => u.Id == model.Id);

        if (user == null)
            return NotFound();

        // aggiorno ApplicationUser
        user.Email = model.Email;
        user.UserName = model.UserName;

        // aggiorno Client (profilo)
        if (user.Client != null && model.Client != null)
        {
            user.Client.FirstName = model.Client.FirstName;
            user.Client.LastName = model.Client.LastName;
            user.Client.PhoneNumber = model.Client.PhoneNumber;
        }

        await _userManager.UpdateAsync(user);

        return RedirectToAction(nameof(Users));
    }

    // =========================
    // DELETE USER
    // =========================
    public async Task<IActionResult> DeleteUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user != null && user.Email != "admin@hotel.com")
            await _userManager.DeleteAsync(user);

        return RedirectToAction(nameof(Users));
    }
}
