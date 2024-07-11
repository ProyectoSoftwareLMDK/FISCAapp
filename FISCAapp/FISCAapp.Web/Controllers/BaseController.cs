using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace FISCAapp.Web.Controllers
{
    public class BaseController<T> : Controller where T : class
    {
        protected readonly AplicacionDbContexto _aplicacionDb;
        protected readonly ILogger<BaseController<T>> _logger;

        public BaseController(AplicacionDbContexto aplicacionDb, ILogger<BaseController<T>> logger)
        {
            _aplicacionDb = aplicacionDb ?? throw new ArgumentNullException(nameof(aplicacionDb));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // Método para manejar excepciones
        protected void HandleException(Exception ex, string errorMessage)
        {
            TempData["error"] = errorMessage + ": " + ex.Message;
            RedirectToAction("Error", "Home");
        }
        protected void LoadReferenceData()
        {
            
            ViewBag.Carreras = _aplicacionDb.Carreras.ToList();
            ViewBag.Grupos = _aplicacionDb.Grupos.ToList();
            ViewBag.Cuatrimestres = _aplicacionDb.Cuatrimestres.ToList();
            ViewBag.Estudiantes = _aplicacionDb.Estudiantes.ToList();
            ViewBag.Docentes = _aplicacionDb.Docentes.ToList();
            ViewBag.Niveles = _aplicacionDb.Niveles.ToList();
            ViewBag.Asignaciones = _aplicacionDb.Asignaciones.ToList();
            ViewBag.Horarios = _aplicacionDb.Horarios.ToList();
            ViewBag.Asignaturas = _aplicacionDb.Asignaturas.ToList();
            ViewBag.Inscripciones_Asignaturas = _aplicacionDb.InscripcionesAsignaturas.ToList();
            ViewBag.Numeros_Asignaciones = _aplicacionDb.NumerosAsignaciones.ToList();
            ViewBag.PlanEstudios = _aplicacionDb.PlanEstudios.ToList();
            ViewBag.Turnos = _aplicacionDb.Turnos.ToList();
        }


        // Método genérico para obtener todos los registros de la entidad T
        protected IQueryable<T> GetAll()
        {
            return _aplicacionDb.Set<T>();
        }

        // Método genérico para agregar un registro de la entidad T
        protected void Add(T entity)
        {
            try
            {
                _aplicacionDb.Set<T>().Add(entity);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "Datos guardados correctamente";
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al guardar los datos");
            }
        }

        // Método genérico para actualizar un registro de la entidad T
        protected void Update(T entity)
        {
            try
            {
                _aplicacionDb.Set<T>().Update(entity);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "Datos actualizados correctamente";
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al actualizar los datos");
            }
        }

        // Método genérico para eliminar un registro de la entidad T por ID
        protected IActionResult Delete(T entity)
        {
            try
            {
                _aplicacionDb.Set<T>().Remove(entity);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "Datos eliminados correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al eliminar los datos");
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
