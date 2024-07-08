using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;


namespace FISCAapp.Web.Controllers
{
    public class CarreraController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;
        public CarreraController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                var carreras = from c in _aplicacionDb.Carreras
                               select c;

                if (!String.IsNullOrEmpty(searchString))
                {
                    carreras = carreras.Where(c => c.NombreCarrera.Contains(searchString));
                }

                var listaCarrera = carreras.ToList();
                ViewData["CurrentFilter"] = searchString;
                return View(listaCarrera);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la lista de carreras: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Carrera carrera)
        {
            if (carrera.NombreCarrera == null || carrera.NombreCarrera.Trim().Length == 0)
            {
                ModelState.AddModelError("NombreCarrera", "El nombre de la carrera es obligatorio.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _aplicacionDb.Carreras.Add(carrera);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "La carrera fue agregada con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al agregar la carrera: " + ex.Message;
                }
            }
            return View(carrera);
        }

        public IActionResult Actualizar(int id)
        {
            try
            {
                var carrera = _aplicacionDb.Carreras.FirstOrDefault(c => c.IdCarrera == id);
                if (carrera == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(carrera);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la carrera: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Carrera carrera)
        {
            if (ModelState.IsValid && carrera.IdCarrera > 0)
            {
                try
                {
                    _aplicacionDb.Carreras.Update(carrera);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "La carrera fue actualizada con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al actualizar la carrera: " + ex.Message;
                }
            }
            return View(carrera);
        }

        public IActionResult Eliminar(int id)
        {
            try
            {
                var carrera = _aplicacionDb.Carreras.FirstOrDefault(c => c.IdCarrera == id);
                if (carrera == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(carrera);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la carrera: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(Carrera carrera)
        {
            if (ModelState.IsValid && carrera.IdCarrera > 0)
            {
                try
                {
                    var carreraDb = _aplicacionDb.Carreras.FirstOrDefault(c => c.IdCarrera == carrera.IdCarrera);
                    if (carreraDb != null)
                    {
                        _aplicacionDb.Carreras.Remove(carreraDb);
                        _aplicacionDb.SaveChanges();
                        TempData["success"] = "La carrera fue eliminada con éxito";
                        return RedirectToAction("Index");
                    }
                    TempData["error"] = "Error al eliminar la carrera";
                    return View(carrera);
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al eliminar la carrera: " + ex.Message;
                    return View(carrera);
                }
            }
            TempData["error"] = "Error al eliminar la carrera";
            return View(carrera);
        }
    }
}
