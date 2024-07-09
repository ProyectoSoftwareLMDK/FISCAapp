using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FISCAapp.Web.Controllers
{
    [Authorize]
    public class NumerosAsignaturasController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public NumerosAsignaturasController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                var docentes = _aplicacionDb.Docentes.ToList();
                ViewBag.Docentes = docentes;

                var numeros_a = from n in _aplicacionDb.NumerosAsignaciones
                              select n;

                if (!String.IsNullOrEmpty(searchString))
                {
                    numeros_a = numeros_a.Where(i => i.NumeroAsignado.ToString().Contains(searchString));
                }
                var listaNumeroAsignacion = numeros_a.ToList();
                ViewData["CurrentFilter"] = searchString;
                return View(listaNumeroAsignacion);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la lista de números de asignación: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Numeros_Asignaciones numeroAsignacion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _aplicacionDb.NumerosAsignaciones.Add(numeroAsignacion);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "Los datos fueron agregados con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al agregar el número de asignación: " + ex.Message;
                }
            }
            return View();
        }

        public IActionResult Actualizar(int idNumeroAsignacion)
        {
            try
            {
                Numeros_Asignaciones? numeroAsignacion = _aplicacionDb.NumerosAsignaciones.FirstOrDefault(n => n.IdNumerosAsignaciones == idNumeroAsignacion);
                if (numeroAsignacion == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(numeroAsignacion);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar el número de asignación para actualizar: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Numeros_Asignaciones numeroAsignacion)
        {
            if (ModelState.IsValid && numeroAsignacion.IdNumerosAsignaciones > 0)
            {
                try
                {
                    _aplicacionDb.NumerosAsignaciones.Update(numeroAsignacion);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "Los datos fueron actualizados con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al actualizar el número de asignación: " + ex.Message;
                }
            }
            return View();
        }

        public IActionResult Eliminar(int idNumeroAsignacion)
        {
            try
            {
                Numeros_Asignaciones? numeroAsignacion = _aplicacionDb.NumerosAsignaciones.FirstOrDefault(n => n.IdNumerosAsignaciones == idNumeroAsignacion);
                if (numeroAsignacion == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(numeroAsignacion);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar el número de asignación para eliminar: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(Numeros_Asignaciones numeroAsignacion)
        {
            try
            {
                if (ModelState.IsValid && numeroAsignacion.IdNumerosAsignaciones > 0)
                {
                    _aplicacionDb.NumerosAsignaciones.Remove(numeroAsignacion);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "Los datos fueron eliminados con éxito";
                    return RedirectToAction("Index");
                }

                TempData["error"] = "No se pudieron eliminar los datos con éxito";
                return View();
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al eliminar el número de asignación: " + ex.Message;
                return View(numeroAsignacion);
            }
        }
    }
}
