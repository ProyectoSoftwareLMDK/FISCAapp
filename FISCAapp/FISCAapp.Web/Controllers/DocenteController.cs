using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;


namespace FISCA.WEB.Controllers
{
    public class DocentesController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;
        public DocentesController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index()
        {
            var listaDocentes = _aplicacionDb.Docentes.ToList();
            return View(listaDocentes);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Docente docente)
        {
            if (ModelState.IsValid)
            {
                _aplicacionDb.Docentes.Add(docente);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "El docente fue agregado con éxito";
                return RedirectToAction("Index");
            }
            return View(docente);
        }

        public IActionResult Actualizar(int id)
        {
            var docente = _aplicacionDb.Docentes.FirstOrDefault(d => d.IdDocente == id);
            if (docente == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(docente);
        }

        [HttpPost]
        public IActionResult Actualizar(Docente docente)
        {
            if (ModelState.IsValid && docente.IdDocente > 0)
            {
                _aplicacionDb.Docentes.Update(docente);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "El docente fue actualizado con éxito";
                return RedirectToAction("Index");
            }
            return View(docente);
        }

        public IActionResult Eliminar(int id)
        {
            var docente = _aplicacionDb.Docentes.FirstOrDefault(d => d.IdDocente == id);
            if (docente == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(docente);
        }

        [HttpPost]
        public IActionResult Eliminar(Docente docente)
        {
            if (ModelState.IsValid && docente.IdDocente > 0)
            {
                _aplicacionDb.Docentes.Remove(docente);
                _aplicacionDb.SaveChanges();
                TempData["error"] = "El docente fue eliminado con éxito";
                return RedirectToAction("Index");
            }
            TempData["error"] = "El docente no fue eliminado";
            return View(docente);
        }
    }
}
