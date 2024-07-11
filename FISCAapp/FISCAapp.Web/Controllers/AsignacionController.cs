using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FISCAapp.Web.Controllers
{
    [Authorize]
    public class AsignacionController : BaseController<Asignacion>
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public AsignacionController(AplicacionDbContexto aplicacionDb, ILogger<BaseController<Asignacion>> logger)
            : base(aplicacionDb, logger)
        {
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                LoadReferenceData();
                var asignaciones = GetAll();
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
                HandleException(ex, "Error al cargar la lista de asignaciones");
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
                    Add(asignacion);   
            }
            LoadReferenceData();
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
                HandleException(ex, "Error al cargar la asignación para actualizar");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Asignacion asignacion)
        {
            if (ModelState.IsValid && asignacion.IdAsignacion > 0)
            {
                    Update(asignacion); // Utiliza el método Update definido en BaseController
                    return RedirectToAction("Index");
            }
            TempData["error"] = "Modelo no valido";
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
                    Delete(asignacion); // Utiliza el método Delete definido en BaseController
            return RedirectToAction("Index");
        }
    }
}
