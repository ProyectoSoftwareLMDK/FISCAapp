using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;


namespace FISCA.WEB.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;
        public EstudiantesController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index()
        {
            var listaEstudiantes = _aplicacionDb.Estudiantes.ToList();
            return View(listaEstudiantes);
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
                _aplicacionDb.Estudiantes.Add(estudiante);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "El estudiante fue agregado con éxito";
                return RedirectToAction("Index");
            }
            return View(estudiante);
        }

        public IActionResult Actualizar(int id)
        {
            var estudiante = _aplicacionDb.Estudiantes.FirstOrDefault(e => e.IdEstudiante == id);
            if (estudiante == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(estudiante);
        }

        [HttpPost]
        public IActionResult Actualizar(Estudiante estudiante)
        {
            if (ModelState.IsValid && estudiante.IdEstudiante > 0)
            {
                _aplicacionDb.Estudiantes.Update(estudiante);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "El estudiante fue actualizado con éxito";
                return RedirectToAction("Index");
            }
            return View(estudiante);
        }

        public IActionResult Eliminar(int id)
        {
            var estudiante = _aplicacionDb.Estudiantes.FirstOrDefault(e => e.IdEstudiante == id);
            if (estudiante == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(estudiante);
        }

        [HttpPost]
        public IActionResult Eliminar(Estudiante estudiante)
        {
            if (ModelState.IsValid && estudiante.IdEstudiante > 0)
            {
                _aplicacionDb.Estudiantes.Remove(estudiante);
                _aplicacionDb.SaveChanges();
                TempData["error"] = "El estudiante fue eliminado con éxito";
                return RedirectToAction("Index");
            }
            TempData["error"] = "El estudiante no fue eliminado";
            return View(estudiante);
        }
    }
}
