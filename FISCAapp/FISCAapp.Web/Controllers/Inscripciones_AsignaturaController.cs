using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FISCAapp.Web.Controllers
{
    [Authorize]
    public class Inscripciones_AsignaturaController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;
        public Inscripciones_AsignaturaController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                var inscripciones = from i in _aplicacionDb.InscripcionesAsignaturas 
                                  select i;

                if (!String.IsNullOrEmpty(searchString))
                {
                    inscripciones = inscripciones.Where(i => i.IdAsignatura.ToString().Contains(searchString));
                }
                var listaInscripcionesAsignaturas = inscripciones.ToList();
                ViewData["CurrentFilter"] = searchString;
                return View(listaInscripcionesAsignaturas);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar las inscripciones de asignaturas: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Inscripciones_Asignaturas inscripcion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _aplicacionDb.InscripcionesAsignaturas.Add(inscripcion);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "La inscripción fue agregada con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al agregar la inscripción: " + ex.Message;
                }
            }
            return View(inscripcion);
        }

        public IActionResult Actualizar(int idInscripcion)
        {
            try
            {
                Inscripciones_Asignaturas? inscripcion = _aplicacionDb.InscripcionesAsignaturas.FirstOrDefault(i => i.IdInscripcion == idInscripcion);
                if (inscripcion == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(inscripcion);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la inscripción para actualizar: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Inscripciones_Asignaturas inscripcion)
        {
            if (ModelState.IsValid && inscripcion.IdInscripcion > 0)
            {
                try
                {
                    _aplicacionDb.InscripcionesAsignaturas.Update(inscripcion);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "La inscripción fue actualizada con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al actualizar la inscripción: " + ex.Message;
                }
            }
            return View(inscripcion);
        }

        public IActionResult Eliminar(int idInscripcion)
        {
            try
            {
                Inscripciones_Asignaturas? inscripcion = _aplicacionDb.InscripcionesAsignaturas.FirstOrDefault(i => i.IdInscripcion == idInscripcion);
                if (inscripcion == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(inscripcion);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la inscripción para eliminar: " + ex.Message;
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
                    _aplicacionDb.InscripcionesAsignaturas.Remove(inscripcion);
                    _aplicacionDb.SaveChanges();
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
