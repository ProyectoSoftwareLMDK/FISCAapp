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
            try
            {
                var listaAsignaciones = _aplicacionDb.Asignaciones.ToList();
                return View(listaAsignaciones);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la lista de asignaciones: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
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
                try
                {
                    _aplicacionDb.Asignaciones.Add(asignacion);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "Asignación creada con éxito";
                    return RedirectToAction("Index");
                } 
                catch (Exception ex)
                {
                    TempData["error"] = "Error al crear la asignación: " + ex.Message;
                }
            }
            return View(asignacion);
        }

        public IActionResult Editar(int id)
        {
            try
            {
                var asignacion = _aplicacionDb.Asignaciones.FirstOrDefault(a => a.IdAsignacion == id);
                if (asignacion == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(asignacion);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la asignación: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Editar(Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _aplicacionDb.Asignaciones.Update(asignacion);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "Asignación actualizada con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al actualizar la asignación: " + ex.Message;
                }
            }
            return View(asignacion);
        }

        public IActionResult Eliminar(int id)
        {
            try
            {
                var asignacion = _aplicacionDb.Asignaciones.FirstOrDefault(a => a.IdAsignacion == id);
                if (asignacion == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(asignacion);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la asignación: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(Asignacion asignacion)
        {
            try
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
            catch (Exception ex)
            {
                TempData["error"] = "Error al eliminar la asignación: " + ex.Message;
                return View(asignacion);
            }
        }
    }
}
