using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FISCAapp.Web.Controllers
{
    [Authorize]
    public class HorarioController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public HorarioController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                var horarios = from h in _aplicacionDb.Horarios
                               select h;

                if (!String.IsNullOrEmpty(searchString))
                {
                    horarios = horarios.Where(h => h.NombreHorario.Contains(searchString));
                }

                var listaHorarios = horarios.ToList();
                ViewData["CurrentFilter"] = searchString;
                return View(listaHorarios);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la lista de horarios: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
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
                try
                {
                    _aplicacionDb.Horarios.Add(horario);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "El horario fue agregado con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al agregar el horario: " + ex.Message;
                }
            }
            return View(horario);
        }

        public IActionResult Actualizar(int id)
        {
            try
            {
                var horario = _aplicacionDb.Horarios.FirstOrDefault(h => h.IdHorario == id);
                if (horario == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(horario);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar el horario: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Horario horario)
        {
            if (ModelState.IsValid && horario.IdHorario > 0)
            {
                try
                {
                    _aplicacionDb.Horarios.Update(horario);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "El horario fue actualizado con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al actualizar el horario: " + ex.Message;
                }
            }
            return View(horario);
        }

        public IActionResult Eliminar(int id)
        {
            try
            {
                var horario = _aplicacionDb.Horarios.FirstOrDefault(h => h.IdHorario == id);
                if (horario == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(horario);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar el horario: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(Horario horario)
        {
            if (ModelState.IsValid && horario.IdHorario > 0)
            {
                try
                {
                    var horarioDb = _aplicacionDb.Horarios.FirstOrDefault(h => h.IdHorario == horario.IdHorario);
                    if (horarioDb != null)
                    {
                        _aplicacionDb.Horarios.Remove(horarioDb);
                        _aplicacionDb.SaveChanges();
                        TempData["success"] = "El horario fue eliminado con éxito";
                        return RedirectToAction("Index");
                    }
                    TempData["error"] = "Error al eliminar el horario";
                    return View(horario);
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al eliminar el horario: " + ex.Message;
                    return View(horario);
                }
            }
            TempData["error"] = "Error al eliminar el horario";
            return View(horario);
        }
    }
}
