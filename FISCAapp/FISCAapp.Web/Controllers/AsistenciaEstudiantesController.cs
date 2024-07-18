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

        public IActionResult Index(int? cursoId)
        {
            try
            {
                if (!cursoId.HasValue)
                {
                    return NotFound();
                }

                // Obtener todas las inscripciones para el cursoId especificado
                var inscripciones = _aplicacionDb.InscripcionesAsignaturas
                                            .Where(i => i.IdAsignacion == cursoId.Value)
                                            .ToList();

                // Obtener los IDs de estudiantes únicos
                var idsEstudiantes = inscripciones.Select(i => i.IdEstudiante).Distinct().ToList();

                // Obtener los estudiantes correspondientes
                var estudiantes = _aplicacionDb.Estudiantes
                                            .Where(e => idsEstudiantes.Contains(e.IdEstudiante))
                                            .ToList();

                ViewData["CursoId"] = cursoId;
                return View(estudiantes);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar la lista de estudiantes inscritos");
                return RedirectToAction("Error", "Home");
            }
        }
        public IActionResult Listar(string searchString)
        {
            try
            {
                var asistenciaEstudiantes = GetAll(); // Cambiado de carrera a asistenciaEstudiantes

                if (!String.IsNullOrEmpty(searchString))
                {
                    asistenciaEstudiantes = asistenciaEstudiantes.Where(ae => ae.Estado.Contains(searchString));
                }

                var listaAsistenciaEstudiantes = asistenciaEstudiantes.ToList(); // Cambiado de listaCarrera a listaAsistenciaEstudiantes
                ViewData["CurrentFilter"] = searchString;
                return View(listaAsistenciaEstudiantes); // Cambiado de listaCarrera a listaAsistenciaEstudiantes
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar la lista de asistencia de estudiantes"); // Mensaje modificado
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
        public IActionResult SeleccionarCurso()
        {
            try
            {
                var cedula = User.Identity.Name; // Asumiendo que el nombre de usuario es el ID del usuario
                var IdDocente = _aplicacionDb.Docentes
    .FirstOrDefault(a => a.CedulaDocente == cedula)?.IdDocente;

                var cursos = _aplicacionDb.Asignaciones.Where(a => a.IdDocente == IdDocente).ToList();

                return View(cursos);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar los cursos del docente");
                return RedirectToAction("Error", "Home");
            }
        }


    }
}
