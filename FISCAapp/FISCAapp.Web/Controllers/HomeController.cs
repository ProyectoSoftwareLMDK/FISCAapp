using FISCA.Infraestructura.Data;
using FISCA.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using FISCAapp.Web.Models;
using System.Diagnostics;

namespace FISCAapp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AplicacionDbContexto _context;

        public HomeController(ILogger<HomeController> logger, AplicacionDbContexto context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Aquí puedes agregar la lógica para validar las credenciales con la base de datos
            var usuario = _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == username && u.PassUsuario == password);

            if (usuario != null)
            {
                // Credenciales válidas, redirigir al menú
                return RedirectToAction("Menu");
            }

            // Credenciales inválidas, mostrar un mensaje de error
            TempData["error"] = "Username o password incorrectos";
            return RedirectToAction("Index");
        }

        public IActionResult Menu()
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
