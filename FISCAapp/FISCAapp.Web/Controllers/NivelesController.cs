using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace FISCAapp.Web.Controllers
{
    [Authorize]
    public class NivelesController : BaseController<Nivel>
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public NivelesController(AplicacionDbContexto aplicacionDb, ILogger<BaseController<Nivel>> logger)
            : base(aplicacionDb, logger)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                

                var niveles = GetAll();

                if (!String.IsNullOrEmpty(searchString))
                {
                    niveles = niveles.Where(n => n.NombreNivel.Contains(searchString));
                }

                var listaNiveles = niveles.ToList();
                ViewData["CurrentFilter"] = searchString;
                return View(listaNiveles);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar la lista de niveles");
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Nivel nivel)
        {
            if (ModelState.IsValid)
            {
                Add(nivel);
                TempData["success"] = "El nivel fue agregado con éxito";
                return RedirectToAction("Index");
            }

            
            return View(nivel);
        }

        public IActionResult Actualizar(int id)
        {
            try
            {
                var nivel = _aplicacionDb.Niveles.FirstOrDefault(n => n.IdNivel == id);
                if (nivel == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                
                return View(nivel);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar el nivel para actualizar");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Nivel nivel)
        {
            if (ModelState.IsValid && nivel.IdNivel > 0)
            {
                Update(nivel);
                TempData["success"] = "El nivel fue actualizado con éxito";
                return RedirectToAction("Index");
            }

           
            return View(nivel);
        }

        public IActionResult Eliminar(int id)
        {
            try
            {
                var nivel = _aplicacionDb.Niveles.FirstOrDefault(n => n.IdNivel == id);
                if (nivel == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(nivel);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar el nivel para eliminar");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(Nivel nivel)
        {
            try
            {
                if (ModelState.IsValid && nivel.IdNivel > 0)
                {
                    Delete(nivel);
                    TempData["success"] = "El nivel fue eliminado con éxito";
                    return RedirectToAction("Index");
                }

                TempData["error"] = "Error al eliminar el nivel";
                return View(nivel);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al eliminar el nivel");
                return View(nivel);
            }
        }
    }
}
