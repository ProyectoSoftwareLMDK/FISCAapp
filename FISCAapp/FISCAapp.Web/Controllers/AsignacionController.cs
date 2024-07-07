using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FISCAapp.Web.Views.Home
{
    public class AsignacionController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public AsignacionController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index()
        {
            var listaAsignaciones = _aplicacionDb.Asignaciones.ToList();
            return View(listaAsignaciones);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                _aplicacionDb.Asignaciones.Add(asignacion);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "Asignación creada con éxito";
                return RedirectToAction("Index");
            }
            return View(asignacion);
        }

        public IActionResult Editar(int id)
        {
            var asignacion = _aplicacionDb.Asignaciones.FirstOrDefault(a => a.IdAsignacion == id);
            if (asignacion == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(asignacion);
        }

        [HttpPost]
        public IActionResult Editar(Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                _aplicacionDb.Asignaciones.Update(asignacion);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "Asignación actualizada con éxito";
                return RedirectToAction("Index");
            }
            return View(asignacion);
        }

        public IActionResult Eliminar(int id)
        {
            var asignacion = _aplicacionDb.Asignaciones.FirstOrDefault(a => a.IdAsignacion == id);
            if (asignacion == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(asignacion);
        }

        [HttpPost]
        public IActionResult Eliminar(Asignacion asignacion)
        {
            var asignacionDb = _aplicacionDb.Asignaciones.FirstOrDefault(a => a.IdAsignacion == asignacion.IdAsignacion);
            if (asignacionDb != null)
            {
                _aplicacionDb.Asignaciones.Remove(asignacionDb);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "Asignación eliminada con éxito";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error al eliminar la asignación";
            return View(asignacion);
        }
    }
}
