using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FISCAapp.Web.Controllers
{
    [Authorize]
    public class NivelesController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public NivelesController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                var niveles = from n in _aplicacionDb.Niveles
                                    select n;

                if (!String.IsNullOrEmpty(searchString))
                {
                    niveles = niveles.Where(i => i.NombreNivel.Contains(searchString));
                }
                var listaNiveles = niveles.ToList();
                ViewData["CurrentFilter"] = searchString;
                return View(listaNiveles);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la lista de niveles: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Nivel nivel)
        {
            if (nivel.NombreNivel == null)
            {
                ModelState.AddModelError("NombreNivel", "El nombre del nivel no puede estar vacío");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _aplicacionDb.Niveles.Add(nivel);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "Los datos fueron agregados con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al agregar el nivel: " + ex.Message;
                }
            }
            return View(nivel);
        }

        public IActionResult Actualizar(int idNivel)
        {
            try
            {
                Nivel? nivel = _aplicacionDb.Niveles.FirstOrDefault(n => n.IdNivel == idNivel);
                if (nivel == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(nivel);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar el nivel para actualizar: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Nivel nivel)
        {
            if (ModelState.IsValid && nivel.IdNivel > 0)
            {
                try
                {
                    _aplicacionDb.Niveles.Update(nivel);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "Los datos fueron actualizados con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al actualizar el nivel: " + ex.Message;
                }
            }
            return View();
        }

        public IActionResult Eliminar(int idNivel)
        {
            try
            {
                Nivel? nivel = _aplicacionDb.Niveles.FirstOrDefault(n => n.IdNivel == idNivel);
                if (nivel == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(nivel);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar el nivel para eliminar: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(Nivel nivel)
        {
            try
            {
                if (ModelState.IsValid && nivel.IdNivel > 0)
                {
                    _aplicacionDb.Niveles.Remove(nivel);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "Los datos fueron eliminados con éxito";
                    return RedirectToAction("Index");
                }

                TempData["error"] = "No se pudieron eliminar los datos con éxito";
                return View();
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al eliminar el nivel: " + ex.Message;
                return View(nivel);
            }
        }
    }
}
