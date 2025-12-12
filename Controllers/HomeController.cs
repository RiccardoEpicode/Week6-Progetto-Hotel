using Microsoft.AspNetCore.Mvc;

namespace Progetto_Venerdi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
