using System.Diagnostics;
using Booking.com.Models;
using Microsoft.AspNetCore.Mvc;

namespace Booking.com.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
