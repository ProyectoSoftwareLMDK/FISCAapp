using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FISCAapp.Web.Controllers
{
    [Authorize]
    public class AsignacionController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public AsignacionController(AplicacionDbContexto contexto)
        {
            _aplicacionDb = contexto;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                var asignaciones = from a in _aplicacionDb.Asignaciones
                                   select a;

                if (!String.IsNullOrEmpty(searchString))
                {
                    asignaciones = asignaciones.Where(a => a.Descripcion.Contains(searchString));
                }

                var listaAsignaciones = asignaciones.ToList();
                ViewData["CurrentFilter"] = searchString;
                return View(listaAsignaciones);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la lista de asignaciones: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _aplicacionDb.Asignaciones.Add(asignacion);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "La asignación fue agregada con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al agregar la asignación: " + ex.Message;
                }
            }
            return View(asignacion);
        }

        public IActionResult Actualizar(int id)
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
        public IActionResult Actualizar(Asignacion asignacion)
        {
            if (ModelState.IsValid && asignacion.IdAsignacion > 0)
            {
                try
                {
                    _aplicacionDb.Asignaciones.Update(asignacion);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "La asignación fue actualizada con éxito";
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
            if (ModelState.IsValid && asignacion.IdAsignacion > 0)
            {
                try
                {
                    var asignacionDb = _aplicacionDb.Asignaciones.FirstOrDefault(a => a.IdAsignacion == asignacion.IdAsignacion);
                    if (asignacionDb != null)
                    {
                        _aplicacionDb.Asignaciones.Remove(asignacionDb);
                        _aplicacionDb.SaveChanges();
                        TempData["success"] = "La asignación fue eliminada con éxito";
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
            TempData["error"] = "Error al eliminar la asignación";
            return View(asignacion);
        }
    }
}
