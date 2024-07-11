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
    public class AsistenciaEstudiantesController : BaseController<AsistenciaEstudiantes>
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public AsistenciaEstudiantesController(AplicacionDbContexto aplicacionDb, ILogger<BaseController<AsistenciaEstudiantes>> logger)
            : base(aplicacionDb, logger)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                LoadReferenceData();
                var asistencias = GetAll();

                if (!String.IsNullOrEmpty(searchString))
                {
                    asistencias = asistencias.Where(a =>
                        _aplicacionDb.Estudiantes.Any(e => e.IdEstudiante == a.IdEstudiante && e.NombresEstudiante.Contains(searchString)) ||
                        _aplicacionDb.Asignaciones.Any(asg => asg.IdAsignacion == a.IdAsignacion && asg.Descripcion.Contains(searchString))
                    );
                }

                var listaAsistencia = asistencias.ToList();
                ViewData["CurrentFilter"] = searchString;
                return View(listaAsistencia);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar la lista de asistencias");
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            LoadReferenceData();
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(AsistenciaEstudiantes asistencia)
        {
            if (ModelState.IsValid)
            {
                Add(asistencia);
                TempData["success"] = "La asistencia fue agregada con éxito";
                return RedirectToAction("Index");
            }

            LoadReferenceData();
            return View(asistencia);
        }

        public IActionResult Actualizar(int id)
        {
            try
            {
                var asistencia = _aplicacionDb.AsistenciaEstudiantes.FirstOrDefault(a => a.IdAsistencia == id);
                if (asistencia == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                LoadReferenceData();
                return View(asistencia);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar la asistencia");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(AsistenciaEstudiantes asistencia)
        {
            if (ModelState.IsValid && asistencia.IdAsistencia > 0)
            {
                Update(asistencia);
                TempData["success"] = "La asistencia fue actualizada con éxito";
                return RedirectToAction("Index");
            }

            LoadReferenceData();
            return View(asistencia);
        }

        public IActionResult Eliminar(int id)
        {
            try
            {
                var asistencia = _aplicacionDb.AsistenciaEstudiantes.FirstOrDefault(a => a.IdAsistencia == id);
                if (asistencia == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(asistencia);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar la asistencia");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(AsistenciaEstudiantes asistencia)
        {
            if (ModelState.IsValid && asistencia.IdAsistencia > 0)
            {
                Delete(asistencia);
                TempData["success"] = "La asistencia fue eliminada con éxito";
                return RedirectToAction("Index");
            }

            TempData["error"] = "Error al eliminar la asistencia";
            return View(asistencia);
        }
    }
}
