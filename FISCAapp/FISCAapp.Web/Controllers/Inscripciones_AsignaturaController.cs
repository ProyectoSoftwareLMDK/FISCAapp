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
    public class Inscripciones_AsignaturaController : BaseController<Inscripciones_Asignaturas>
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public Inscripciones_AsignaturaController(AplicacionDbContexto aplicacionDb, ILogger<BaseController<Inscripciones_Asignaturas>> logger)
            : base(aplicacionDb, logger)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                LoadReferenceData();

                var inscripciones = GetAll();

                if (!String.IsNullOrEmpty(searchString))
                {
                    inscripciones = inscripciones.Where(i => i.IdInscripcion.ToString().Contains(searchString));
                }

                var listaInscripcionesAsignaturas = inscripciones.ToList();
                ViewData["CurrentFilter"] = searchString;
                return View(listaInscripcionesAsignaturas);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar las inscripciones de asignaturas");
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            LoadReferenceData();
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Inscripciones_Asignaturas inscripcion)
        {
            if (ModelState.IsValid)
            {
                Add(inscripcion);
                TempData["success"] = "La inscripción fue agregada con éxito";
                return RedirectToAction("Index");
            }

            LoadReferenceData();
            return View(inscripcion);
        }

        public IActionResult Actualizar(int id)
        {
            try
            {
                var inscripcion = _aplicacionDb.InscripcionesAsignaturas.FirstOrDefault(i => i.IdInscripcion == id);
                if (inscripcion == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                LoadReferenceData();
                return View(inscripcion);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar la inscripción para actualizar");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Inscripciones_Asignaturas inscripcion)
        {
            if (ModelState.IsValid && inscripcion.IdInscripcion > 0)
            {
                Update(inscripcion);
                TempData["success"] = "La inscripción fue actualizada con éxito";
                return RedirectToAction("Index");
            }

            LoadReferenceData();
            return View(inscripcion);
        }

        public IActionResult Eliminar(int id)
        {
            try
            {
                var inscripcion = _aplicacionDb.InscripcionesAsignaturas.FirstOrDefault(i => i.IdInscripcion == id);
                if (inscripcion == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(inscripcion);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar la inscripción para eliminar");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(Inscripciones_Asignaturas inscripcion)
        {
            try
            {
                if (ModelState.IsValid && inscripcion.IdInscripcion > 0)
                {
                    Delete(inscripcion);
                    TempData["success"] = "La inscripción fue eliminada con éxito";
                    return RedirectToAction("Index");
                }
                TempData["error"] = "Error al eliminar la inscripción";
                return View(inscripcion);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al eliminar la inscripción: " + ex.Message;
                return View(inscripcion);
            }
        }
    }
}
