using Booking.com.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Booking.com.Models.Entities;

public class AccountController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IUserService _userService;

    public AccountController(
        SignInManager<ApplicationUser> signInManager,
        IUserService userService)
    {
        _signInManager = signInManager;
        _userService = userService;
    }

    // -------- LOGIN --------
    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(
        string email,
        string password,
        string? returnUrl = null)
    {
        var result = await _signInManager.PasswordSignInAsync(
            email, password, false, false);

        if (result.Succeeded)
            return Redirect(returnUrl ?? "/");

        ModelState.AddModelError("", "Credenziali errate");
        return View();
    }

    // -------- REGISTER --------
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(
        string email,
        string password,
        string firstName,
        string lastName,
        string phoneNumber)
    {
        await _userService.RegisterUserAsync(
            email, password, firstName, lastName, phoneNumber);

        await _signInManager.PasswordSignInAsync(
            email, password, false, false);

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
