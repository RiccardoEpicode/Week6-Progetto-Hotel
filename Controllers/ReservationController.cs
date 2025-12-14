using Booking.com.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Booking.com.Models.Entities;

[Authorize]
public class ReservationController : Controller
{
    private readonly IReservationService _service;
    private readonly UserManager<ApplicationUser> _userManager;

    public ReservationController(
        IReservationService service,
        UserManager<ApplicationUser> userManager)
    {
        _service = service;
        _userManager = userManager;
    }

    // =========================
    // STEP 1: MOSTRA FORM DATE
    // =========================
    [HttpGet]
    public IActionResult Create(Guid roomId)
    {
        ViewBag.RoomId = roomId;
        return View();
    }

    // =========================
    // STEP 2: SALVA PRENOTAZIONE
    // =========================
    [HttpPost]
    public IActionResult Create(
        Guid roomId,
        DateTime startDate,
        DateTime endDate)
    {
        if (startDate >= endDate)
        {
            ModelState.AddModelError("", "Le date non sono valide");
            ViewBag.RoomId = roomId;
            return View();
        }

        var user = _userManager.Users
            .First(u => u.UserName == User.Identity!.Name);

        _service.Create(roomId, user.ClientId!.Value, startDate, endDate);

        return RedirectToAction(nameof(MyReservations));
    }

    // =========================
    // MIE PRENOTAZIONI
    // =========================
    public IActionResult MyReservations()
    {
        var user = _userManager.Users
            .First(u => u.UserName == User.Identity!.Name);

        return View(_service.GetByClient(user.ClientId!.Value));
    }
}
