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
    public class CarreraController : BaseController<Carrera>
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public CarreraController(AplicacionDbContexto aplicacionDb, ILogger<BaseController<Carrera>> logger)
            : base(aplicacionDb, logger)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                
                var carreras = GetAll();

                if (!String.IsNullOrEmpty(searchString))
                {
                    carreras = carreras.Where(c => c.NombreCarrera.Contains(searchString));
                }

                var listaCarrera = carreras.ToList();
                ViewData["CurrentFilter"] = searchString;
                return View(listaCarrera);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar la lista de carreras");
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Carrera carrera)
        {
            if (carrera.NombreCarrera == null || carrera.NombreCarrera.Trim().Length == 0)
            {
                ModelState.AddModelError("NombreCarrera", "El nombre de la carrera es obligatorio.");
            }

            if (ModelState.IsValid)
            {
                Add(carrera);
                TempData["success"] = "La carrera fue agregada con éxito";
                return RedirectToAction("Index");
            }

            
            return View(carrera);
        }

        public IActionResult Actualizar(int id)
        {
            try
            {
                var carrera = _aplicacionDb.Carreras.FirstOrDefault(c => c.IdCarrera == id);
                if (carrera == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                
                return View(carrera);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar la carrera");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Carrera carrera)
        {
            if (ModelState.IsValid && carrera.IdCarrera > 0)
            {
                Update(carrera);
                TempData["success"] = "La carrera fue actualizada con éxito";
                return RedirectToAction("Index");
            }

            
            return View(carrera);
        }

        public IActionResult Eliminar(int id)
        {
            try
            {
                var carrera = _aplicacionDb.Carreras.FirstOrDefault(c => c.IdCarrera == id);
                if (carrera == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(carrera);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar la carrera");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(Carrera carrera)
        {
            if (ModelState.IsValid && carrera.IdCarrera > 0)
            {
                Delete(carrera);
                TempData["success"] = "La carrera fue eliminada con éxito";
                return RedirectToAction("Index");
            }

            TempData["error"] = "Error al eliminar la carrera";
            return View(carrera);
        }
    }
}
