using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;


namespace FISCAapp.Web.Controllers
{
    public class TurnosController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;
        public TurnosController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                var turnos = from t in _aplicacionDb.Turnos
                             select t;

                if (!String.IsNullOrEmpty(searchString))
                {
                    turnos = turnos.Where(t => t.NombreTurno.Contains(searchString) || t.IdTurno.ToString().Contains(searchString));
                }

                var listaTurnos = turnos.ToList();
                ViewData["CurrentFilter"] = searchString;
                return View(listaTurnos);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la lista de turnos: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Turno turno)
        {
            if (ModelState.IsValid)
            {
                _aplicacionDb.Turnos.Add(turno);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "El turno fue agregado con éxito";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Actualizar(int id)
        {
            var turno = _aplicacionDb.Turnos.FirstOrDefault(t => t.IdTurno == id);
            if (turno == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(turno);
        }

        [HttpPost]
        public IActionResult Actualizar(Turno turno)
        {
            if (ModelState.IsValid && turno.IdTurno > 0)
            {
                _aplicacionDb.Turnos.Update(turno);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "El turno fue actualizado con éxito";
                return RedirectToAction("Index");
            }
            return View(turno);
        }

        public IActionResult Eliminar(int id)
        {
            var turno = _aplicacionDb.Turnos.FirstOrDefault(t => t.IdTurno == id);
            if (turno == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(turno);
        }

        [HttpPost]
        public IActionResult Eliminar(Turno turno)
        {
            if (ModelState.IsValid && turno.IdTurno > 0)
            {
                _aplicacionDb.Turnos.Remove(turno);
                _aplicacionDb.SaveChanges();
                TempData["error"] = "El turno fue eliminado con éxito";
                return RedirectToAction("Index");
            }
            TempData["error"] = "El turno no fue eliminado";
            return View(turno);
        }
    }
}
