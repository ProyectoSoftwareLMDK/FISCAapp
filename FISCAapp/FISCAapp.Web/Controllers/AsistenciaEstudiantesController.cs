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

        public IActionResult Index(int cursoId)
        {
            // Obtener estudiantes inscritos en la asignación
            var estudiantes = _aplicacionDb.Estudiantes.ToList();
            var asignacion = _aplicacionDb.Asignaciones.FirstOrDefault(a => a.IdAsignacion == cursoId)?.Descripcion;

            if (asignacion == null)
            {
                TempData["ErrorMessage"] = "La asignación seleccionada no existe.";
                return RedirectToAction("Index");
            }

            ViewData["CursoId"] = cursoId;

            // Tuple con la lista de estudiantes y nombre de la asignación
            var model = new Tuple<IEnumerable<Estudiante>, int, string>(estudiantes, cursoId, asignacion);

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int IdAsignacion, Dictionary<int, string> asistencia)
        {
            try
            {
                // Verificar si el IdAsignacion existe
                var asignacionExists = _aplicacionDb.Asignaciones.Any(a => a.IdAsignacion == IdAsignacion);

                if (!asignacionExists)
                {
                    TempData["ErrorMessage"] = "La asignación seleccionada no existe.";
                    return RedirectToAction("Index");
                }

                // Procesar la asistencia marcada
                var asistencias = new List<AsistenciaEstudiantes>();
                foreach (var (idEstudiante, estado) in asistencia)
                {
                    var asistenciaEstudiante = new AsistenciaEstudiantes
                    {
                        IdAsignacion = IdAsignacion,
                        IdEstudiante = idEstudiante,
                        Fecha = DateTime.Today,
                        Estado = estado // Ajusta según el valor del checkbox (Presente, Tarde, Falta)
                    };

                    _aplicacionDb.AsistenciaEstudiantes.Add(asistenciaEstudiante);
                }

                _aplicacionDb.SaveChanges();

                TempData["SuccessMessage"] = "Asistencia registrada correctamente.";

                return RedirectToAction("Index", new { IdAsignacion });
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al registrar la asistencia");
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
                try
                {
                    _aplicacionDb.AsistenciaEstudiantes.Add(asistencia);
                    _aplicacionDb.SaveChanges();

                    TempData["success"] = "La asistencia fue agregada con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    HandleException(ex, "Error al agregar la asistencia");
                    return RedirectToAction("Error", "Home");
                }
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
