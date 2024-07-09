using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FISCAapp.Web.Controllers
{
    [Authorize]
    public class AsignaturaController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public AsignaturaController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                var asignaturas = from a in _aplicacionDb.Asignaturas
                               select a;

                if (!String.IsNullOrEmpty(searchString))
                {
                    asignaturas = asignaturas.Where(a => a.NombreAsignatura.Contains(searchString));
                }
                var listaAsignaturas = asignaturas.ToList();
                ViewData["CurrentFilter"] = searchString;
                return View(listaAsignaturas);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la lista de asignaturas: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _aplicacionDb.Asignaturas.Add(asignatura);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "Los datos fueron agregados con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al agregar la asignatura: " + ex.Message;
                }
            }
            return View();
        }

        public IActionResult Actualizar(int idAsignatura)
        {
            try
            {
                Asignatura? asignatura = _aplicacionDb.Asignaturas.FirstOrDefault(a => a.IdAsignatura == idAsignatura);
                if (asignatura == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(asignatura);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la asignatura para actualizar: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Asignatura asignatura)
        {
            if (ModelState.IsValid && asignatura.IdAsignatura > 0)
            {
                try
                {
                    _aplicacionDb.Asignaturas.Update(asignatura);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "Los datos fueron actualizados con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al actualizar la asignatura: " + ex.Message;
                }
            }
            return View();
        }

        public IActionResult Eliminar(int idAsignatura)
        {
            try
            {
                Asignatura? asignatura = _aplicacionDb.Asignaturas.FirstOrDefault(a => a.IdAsignatura == idAsignatura);
                if (asignatura == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(asignatura);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la asignatura para eliminar: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(Asignatura asignatura)
        {
            try
            {
                if (ModelState.IsValid && asignatura.IdAsignatura > 0)
                {
                    _aplicacionDb.Asignaturas.Remove(asignatura);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "Los datos fueron eliminados con éxito";
                    return RedirectToAction("Index");
                }

                TempData["error"] = "No se pudieron eliminar los datos con éxito";
                return View();
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al eliminar la asignatura: " + ex.Message;
                return View(asignatura);
            }
        }
    }
}
