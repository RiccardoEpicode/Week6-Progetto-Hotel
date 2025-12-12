using HotelReservationApp.Models.Entities;
using HotelReservationApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApp.Controllers
{
    public class PrenotazioneController : Controller
    {
        private readonly IPrenotazioneService _service;
        private readonly IClienteService _clienteService;
        private readonly ICameraService _cameraService;

        public PrenotazioneController(
            IPrenotazioneService service,
            IClienteService clienteService,
            ICameraService cameraService)
        {
            _service = service;
            _clienteService = clienteService;
            _cameraService = cameraService;
        }

        [Authorize(Roles = "Admin,Manager,Viewer")]
        public IActionResult Index() => View(_service.GetAll());

        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Create()
        {
            ViewBag.Clienti = _clienteService.GetAll();
            ViewBag.Camere = _cameraService.GetAll();
            return View();
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public IActionResult Create(Prenotazione p)
        {
            _service.Add(p);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Edit(int id)
        {
            ViewBag.Clienti = _clienteService.GetAll();
            ViewBag.Camere = _cameraService.GetAll();
            return View(_service.GetById(id));
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public IActionResult Edit(Prenotazione p)
        {
            _service.Update(p);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
