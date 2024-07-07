using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;

namespace FISCAapp.Web.Controllers
{
    public class HorarioController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;
        public HorarioController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index()
        {
            var listaHorarios = _aplicacionDb.Horarios.ToList();
            return View(listaHorarios);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Horario horario)
        {
            if (string.IsNullOrWhiteSpace(horario.NombreHorario))
            {
                ModelState.AddModelError("NombreHorario", "El nombre del horario es obligatorio.");
            }

            if (ModelState.IsValid)
            {
                _aplicacionDb.Horarios.Add(horario);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "El horario fue agregado con éxito";
                return RedirectToAction("Index");
            }
            return View(horario);
        }

        public IActionResult Actualizar(int id)
        {
            var horario = _aplicacionDb.Horarios.FirstOrDefault(h => h.IdHorario == id);
            if (horario == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(horario);
        }

        [HttpPost]
        public IActionResult Actualizar(Horario horario)
        {
            if (ModelState.IsValid && horario.IdHorario > 0)
            {
                _aplicacionDb.Horarios.Update(horario);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "El horario fue actualizado con éxito";
                return RedirectToAction("Index");
            }
            return View(horario);
        }

        public IActionResult Eliminar(int id)
        {
            var horario = _aplicacionDb.Horarios.FirstOrDefault(h => h.IdHorario == id);
            if (horario == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(horario);
        }

        [HttpPost]
        public IActionResult Eliminar(Horario horario)
        {
            if (ModelState.IsValid && horario.IdHorario > 0)
            {
                _aplicacionDb.Horarios.Remove(horario);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "El horario fue eliminado con éxito";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error al eliminar el horario";
            return View(horario);
        }
    }
}
