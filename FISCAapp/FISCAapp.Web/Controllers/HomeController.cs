using FISCA.Infraestructura.Data;
using FISCA.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using FISCAapp.Web.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;

namespace FISCAapp.Web.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Validar credenciales con la base de datos
            var usuario = _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == username && u.PassUsuario == password);

            if (usuario != null)
            {
                // Credenciales válidas, crear las claims
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim("NivelUsuario", usuario.NivelUsuario.ToString()) // Añadir el nivel de usuario como claim
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Iniciar sesión
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                // Redirigir según el nivel de usuario
                if (usuario.NivelUsuario == 1) // Asumiendo que 1 es admin
                {
                    return RedirectToAction("Menu");
                }
                else if (usuario.NivelUsuario == 8) // Asumiendo que 2 es docente
                {
                    return RedirectToAction("SeleccionarCurso", "AsistenciaEstudiantes");
                }
            }

            // Credenciales inválidas, mostrar un mensaje de error
            TempData["error"] = "Username o password incorrectos";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Cerrar la sesión del usuario
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirigir a la página de inicio o de inicio de sesión
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
