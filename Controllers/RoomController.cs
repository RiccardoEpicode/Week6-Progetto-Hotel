using Booking.com.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

public class RoomController : Controller
{
    private readonly IRoomService _service;

    public RoomController(IRoomService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        return View(_service.GetAll());
    }
}
