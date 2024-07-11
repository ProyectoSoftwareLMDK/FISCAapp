using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace FISCAapp.Web.Controllers
{
    public class EstudiantesController : BaseController<Estudiante>
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public EstudiantesController(AplicacionDbContexto aplicacionDb, ILogger<BaseController<Estudiante>> logger)
            : base(aplicacionDb, logger)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                
                var estudiantes = GetAll();

                if (!String.IsNullOrEmpty(searchString))
                {
                    estudiantes = estudiantes.Where(e => e.NombresEstudiante.Contains(searchString) || e.CedulaEstudiante.Contains(searchString));
                }

                var listaEstudiantes = estudiantes.ToList();
                ViewData["CurrentFilter"] = searchString;
                return View(listaEstudiantes);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar la lista de estudiantes");
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                Add(estudiante);
                TempData["success"] = "El estudiante fue agregado con éxito";
                return RedirectToAction("Index");
            }
            
            return View(estudiante);
        }

        public IActionResult Actualizar(int id)
        {
            try
            {
                var estudiante = _aplicacionDb.Estudiantes.FirstOrDefault(e => e.IdEstudiante == id);
                if (estudiante == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                
                return View(estudiante);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar el estudiante");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Estudiante estudiante)
        {
            if (ModelState.IsValid && estudiante.IdEstudiante > 0)
            {
                Update(estudiante);
                TempData["success"] = "El estudiante fue actualizado con éxito";
                return RedirectToAction("Index");
            }
            
            return View(estudiante);
        }

        public IActionResult Eliminar(int id)
        {
            try
            {
                var estudiante = _aplicacionDb.Estudiantes.FirstOrDefault(e => e.IdEstudiante == id);
                if (estudiante == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(estudiante);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar el estudiante");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(Estudiante estudiante)
        {
            if (ModelState.IsValid && estudiante.IdEstudiante > 0)
            {
                try
                {
                    var estudianteDb = _aplicacionDb.Estudiantes.FirstOrDefault(e => e.IdEstudiante == estudiante.IdEstudiante);
                    if (estudianteDb != null)
                    {
                        Delete(estudianteDb);
                        TempData["success"] = "El estudiante fue eliminado con éxito";
                        return RedirectToAction("Index");
                    }
                    TempData["error"] = "Error al eliminar el estudiante";
                    return View(estudiante);
                }
                catch (Exception ex)
                {
                    HandleException(ex, "Error al eliminar el estudiante");
                    return View(estudiante);
                }
            }

            TempData["error"] = "Error al eliminar el estudiante";
            return View(estudiante);
        }
    }
}
