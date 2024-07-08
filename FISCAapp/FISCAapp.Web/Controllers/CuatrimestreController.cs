using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;

namespace FISCAapp.Web.Controllers
{
    public class CuatrimestreController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;
        public CuatrimestreController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index()
        {
            try
            {
                var listaCuatrimestres = _aplicacionDb.Cuatrimestres.ToList();
                return View(listaCuatrimestres);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la lista de cuatrimestres: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Cuatrimestre cuatrimestre)
        {
            if (string.IsNullOrWhiteSpace(cuatrimestre.NombreCuatrimestre))
            {
                ModelState.AddModelError("NombreCuatrimestre", "El nombre del cuatrimestre es obligatorio.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _aplicacionDb.Cuatrimestres.Add(cuatrimestre);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "El cuatrimestre fue agregado con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al agregar el cuatrimestre: " + ex.Message;
                }
            }
            return View(cuatrimestre);
        }

        public IActionResult Actualizar(int id)
        {
            try
            {
                var cuatrimestre = _aplicacionDb.Cuatrimestres.FirstOrDefault(c => c.IdCuatrimestre == id);
                if (cuatrimestre == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(cuatrimestre);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar el cuatrimestre: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Cuatrimestre cuatrimestre)
        {
            if (ModelState.IsValid && cuatrimestre.IdCuatrimestre > 0)
            {
                try
                {
                    _aplicacionDb.Cuatrimestres.Update(cuatrimestre);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "El cuatrimestre fue actualizado con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al actualizar el cuatrimestre: " + ex.Message;
                }
            }
            return View(cuatrimestre);
        }

        public IActionResult Eliminar(int id)
        {
            try
            {
                var cuatrimestre = _aplicacionDb.Cuatrimestres.FirstOrDefault(c => c.IdCuatrimestre == id);
                if (cuatrimestre == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(cuatrimestre);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar el cuatrimestre: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(Cuatrimestre cuatrimestre)
        {
            if (ModelState.IsValid && cuatrimestre.IdCuatrimestre > 0)
            {
                try
                {
                    var cuatrimestreDb = _aplicacionDb.Cuatrimestres.FirstOrDefault(c => c.IdCuatrimestre == cuatrimestre.IdCuatrimestre);
                    if (cuatrimestreDb != null)
                    {
                        _aplicacionDb.Cuatrimestres.Remove(cuatrimestreDb);
                        _aplicacionDb.SaveChanges();
                        TempData["success"] = "El cuatrimestre fue eliminado con éxito";
                        return RedirectToAction("Index");
                    }
                    TempData["error"] = "Error al eliminar el cuatrimestre";
                    return View(cuatrimestre);
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al eliminar el cuatrimestre: " + ex.Message;
                    return View(cuatrimestre);
                }
            }
            TempData["error"] = "Error al eliminar el cuatrimestre";
            return View(cuatrimestre);
        }
    }
}
