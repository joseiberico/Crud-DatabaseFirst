using Crud_databasefirst.Models;
using Crud_databasefirst.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Crud_databasefirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactoRepository<Contacto> _contactoRepository;
        

        public HomeController(ILogger<HomeController> logger , IContactoRepository<Contacto> contactoRepository)
        {
            _logger = logger;
            _contactoRepository = contactoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var contactos = await _contactoRepository.GetAll();
            return View(contactos);
        }

        public IActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Agregar(Contacto entity)
        {
            var contacto = await _contactoRepository.Create(entity);
            if (contacto == null)
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Actualizar(int id)
        {
            var contacto = await _contactoRepository.GetById(id);
            return View(contacto);
        }
        [HttpPost]
        public async Task<IActionResult> Actualizar(Contacto entity)
        {
            var contacto = await _contactoRepository.Update(entity);
            if (contacto == null)
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var contacto = await _contactoRepository.GetById(id);
            return View(contacto);
        }
        [HttpPost]
        public async Task<IActionResult> confirmarEliminar(Contacto entity)
        {
            var contacto = await _contactoRepository.Delete(entity.IdContacto);
            if (contacto == null)
            {
                return View();
            }

            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}