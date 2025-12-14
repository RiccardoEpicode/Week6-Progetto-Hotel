using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Booking.com.Models.Entities;

[Authorize]
public class ProfileController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ProfileController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.Users
            .Include(u => u.Client)
            .FirstOrDefaultAsync(u => u.UserName == User.Identity!.Name);

        if (user == null || user.Client == null)
            return RedirectToAction("Index", "Home");

        return View(user.Client);
    }

    [HttpPost]
    public IActionResult RequestProfileChange(string email, string message)
    {
        TempData["RequestSent"] = true;
        return RedirectToAction(nameof(Index));
    }

}
