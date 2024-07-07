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
            var listaCuatrimestres = _aplicacionDb.Cuatrimestres.ToList();
            return View(listaCuatrimestres);
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
                _aplicacionDb.Cuatrimestres.Add(cuatrimestre);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "El cuatrimestre fue agregado con éxito";
                return RedirectToAction("Index");
            }
            return View(cuatrimestre);
        }

        public IActionResult Actualizar(int id)
        {
            var cuatrimestre = _aplicacionDb.Cuatrimestres.FirstOrDefault(c => c.IdCuatrimestre == id);
            if (cuatrimestre == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(cuatrimestre);
        }

        [HttpPost]
        public IActionResult Actualizar(Cuatrimestre cuatrimestre)
        {
            if (ModelState.IsValid && cuatrimestre.IdCuatrimestre > 0)
            {
                _aplicacionDb.Cuatrimestres.Update(cuatrimestre);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "El cuatrimestre fue actualizado con éxito";
                return RedirectToAction("Index");
            }
            return View(cuatrimestre);
        }

        public IActionResult Eliminar(int id)
        {
            var cuatrimestre = _aplicacionDb.Cuatrimestres.FirstOrDefault(c => c.IdCuatrimestre == id);
            if (cuatrimestre == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(cuatrimestre);
        }

        [HttpPost]
        public IActionResult Eliminar(Cuatrimestre cuatrimestre)
        {
            if (ModelState.IsValid && cuatrimestre.IdCuatrimestre > 0)
            {
                _aplicacionDb.Cuatrimestres.Remove(cuatrimestre);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "El cuatrimestre fue eliminado con éxito";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error al eliminar el cuatrimestre";
            return View(cuatrimestre);
        }
    }
}
