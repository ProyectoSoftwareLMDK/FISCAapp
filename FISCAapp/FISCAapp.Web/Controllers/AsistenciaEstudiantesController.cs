using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Index()
        {
            var estudiantes = _aplicacionDb.Estudiantes.ToList();
            var asignaciones = _aplicacionDb.Asignaciones.ToList();

            ViewBag.Estudiantes = estudiantes;
            ViewBag.Asignaciones = asignaciones;

            // Aquí se consulta la tabla AsistenciaEstudiantes sin incluir entidades adicionales como estudiantes o asignaciones
            var listaAsistencia = _aplicacionDb.AsistenciaEstudiantes.ToList();

            return View(listaAsistencia);
        }




        public IActionResult Agregar()
        {
            var estudiantes = _aplicacionDb.Estudiantes.ToList();
            var asignaciones = _aplicacionDb.Asignaciones.ToList();

            ViewBag.Estudiantes = estudiantes;
            ViewBag.Asignaciones = asignaciones;

            return View();
        }

        // Ejemplo de método para procesar el formulario de Agregar
        [HttpPost]
        public IActionResult Agregar(AsistenciaEstudiantes asistencia)
        {
            if (ModelState.IsValid)
            {
                // Lógica para guardar la asistencia en la base de datos
                _aplicacionDb.AsistenciaEstudiantes.Add(asistencia);
                _aplicacionDb.SaveChanges();

                TempData["success"] = "La asistencia fue agregada con éxito";
                return RedirectToAction("Index");
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
