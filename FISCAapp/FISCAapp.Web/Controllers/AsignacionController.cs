using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index()
        {
            var asignaciones = _aplicacionDb.Asignaciones.ToList();
            return View(asignaciones);
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

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                _aplicacionDb.Asignaciones.Add(asignacion);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "La asignación fue agregada con éxito";
                return RedirectToAction("Index");
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

        public IActionResult Actualizar(int id)
        {
            var asignacion = _aplicacionDb.Asignaciones.FirstOrDefault(a => a.IdAsignacion == id);
            if (asignacion == null)
                try
                {
                    
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
            return View(asignacion);
        }

        [HttpPost]
        public IActionResult Actualizar(Asignacion asignacion)
        {
            if (ModelState.IsValid && asignacion.IdAsignacion > 0)
            {
                _aplicacionDb.Asignaciones.Update(asignacion);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "La asignación fue actualizada con éxito";
                return RedirectToAction("Index");
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
            var asignacion = _aplicacionDb.Asignaciones.FirstOrDefault(a => a.IdAsignacion == id);
            if (asignacion == null)
                try
                {
                  
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
            return View();
        }

        [HttpPost]
        public IActionResult Eliminar(Asignacion asignacion)
        {
            if (ModelState.IsValid && asignacion.IdAsignacion > 0)
            {
                _aplicacionDb.Asignaciones.Remove(asignacion);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "La asignación fue eliminada con éxito";
                return RedirectToAction("Index");
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
                
            }return View(asignacion);
        }
    }
}

