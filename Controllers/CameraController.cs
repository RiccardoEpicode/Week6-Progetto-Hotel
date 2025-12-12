using HotelReservationApp.Models.Entities;
using HotelReservationApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CameraController : Controller
    {
        private readonly ICameraService _service;

        public CameraController(ICameraService service)
        {
            _service = service;
        }

        public IActionResult Index() => View(_service.GetAll());

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Camera c)
        {
            _service.Add(c);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id) => View(_service.GetById(id));

        [HttpPost]
        public IActionResult Edit(Camera c)
        {
            _service.Update(c);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
