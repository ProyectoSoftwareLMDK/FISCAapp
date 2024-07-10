using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FISCAapp.Web.Controllers
{
    [Authorize]
    public class AsistenciaEstudiantesController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public AsistenciaEstudiantesController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                var estudiantes = _aplicacionDb.Estudiantes.ToList();
                var asignaciones = _aplicacionDb.Asignaciones.ToList();

                ViewBag.Estudiantes = estudiantes;
                ViewBag.Asignaciones = asignaciones;

                // Consulta básica de todas las asistencias
                var asistencias = from a in _aplicacionDb.AsistenciaEstudiantes
                                  select a;

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
                TempData["error"] = "Error al cargar la lista de asistencias: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            var estudiantes = _aplicacionDb.Estudiantes.ToList();
            var asignaciones = _aplicacionDb.Asignaciones.ToList();

            ViewBag.Estudiantes = estudiantes;
            ViewBag.Asignaciones = asignaciones;

            return View();
        }

        [HttpPost]
        public IActionResult Agregar(AsistenciaEstudiantes asistencia)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Lógica para guardar la asistencia en la base de datos
                    _aplicacionDb.AsistenciaEstudiantes.Add(asistencia);
                    _aplicacionDb.SaveChanges();

                    TempData["success"] = "La asistencia fue agregada con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al agregar la asistencia: " + ex.Message;
                }
            }

            // Si hay errores de validación, recargar la vista con datos necesarios
            var estudiantes = _aplicacionDb.Estudiantes.ToList();
            var asignaciones = _aplicacionDb.Asignaciones.ToList();

            ViewBag.Estudiantes = estudiantes;
            ViewBag.Asignaciones = asignaciones;

            return View(asistencia);
        }

        public IActionResult Actualizar(int id)
        {
            var asistencia = _aplicacionDb.AsistenciaEstudiantes.FirstOrDefault(a => a.IdAsistencia == id);
            if (asistencia == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(asistencia);
        }

        [HttpPost]
        public IActionResult Actualizar(AsistenciaEstudiantes asistencia)
        {
            if (ModelState.IsValid && asistencia.IdAsistencia > 0)
            {
                _aplicacionDb.AsistenciaEstudiantes.Update(asistencia);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "La asistencia fue actualizada con éxito";
                return RedirectToAction("Index");
            }
            return View(asistencia);
        }

        public IActionResult Eliminar(int id)
        {
            var asistencia = _aplicacionDb.AsistenciaEstudiantes.FirstOrDefault(a => a.IdAsistencia == id);
            if (asistencia == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(asistencia);
        }

        [HttpPost]
        public IActionResult Eliminar(AsistenciaEstudiantes asistencia)
        {
            if (ModelState.IsValid && asistencia.IdAsistencia > 0)
            {
                _aplicacionDb.AsistenciaEstudiantes.Remove(asistencia);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "La asistencia fue eliminada con éxito";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error al eliminar la asistencia";
            return View(asistencia);
        }
    }
}
