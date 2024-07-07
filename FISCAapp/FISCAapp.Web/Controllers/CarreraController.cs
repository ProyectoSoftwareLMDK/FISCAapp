using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;

namespace FISCAapp.Web.Controllers
{
    public class CarreraController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;
        public CarreraController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index()
        {
            var listaCarrera = _aplicacionDb.Carreras.ToList();
            return View(listaCarrera);
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
                _aplicacionDb.Carreras.Add(carrera);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "La carrera fue agregada con éxito";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Actualizar(int id)
        {
            var carrera = _aplicacionDb.Carreras.FirstOrDefault(c => c.IdCarrera == id);
            if (carrera == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(carrera);
        }

        [HttpPost]
        public IActionResult Actualizar(Carrera carrera)
        {
            if (ModelState.IsValid && carrera.IdCarrera > 0)
            {
                _aplicacionDb.Carreras.Update(carrera);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "La carrera fue actualizada con éxito";
                return RedirectToAction("Index");
            }
            return View(carrera);
        }

        public IActionResult Eliminar(int id)
        {
            var carrera = _aplicacionDb.Carreras.FirstOrDefault(c => c.IdCarrera == id);
            if (carrera == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(carrera);
        }

        [HttpPost]
        public IActionResult Eliminar(Carrera carrera)
        {
            if (ModelState.IsValid && carrera.IdCarrera > 0)
            {
                _aplicacionDb.Carreras.Remove(carrera);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "La carrera fue eliminada con éxito";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error al eliminar la carrera";
            return View(carrera);
        }
    }
}
