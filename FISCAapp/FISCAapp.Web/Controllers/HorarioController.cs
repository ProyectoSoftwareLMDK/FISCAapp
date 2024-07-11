using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace FISCAapp.Web.Controllers
{
    [Authorize]
    public class HorarioController : BaseController<Horario>
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public HorarioController(AplicacionDbContexto aplicacionDb, ILogger<BaseController<Horario>> logger)
            : base(aplicacionDb, logger)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                
                var horarios = GetAll();

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
                HandleException(ex, "Error al cargar la lista de horarios");
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
                Add(horario);
                TempData["success"] = "El horario fue agregado con éxito";
                return RedirectToAction("Index");
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
                HandleException(ex, "Error al cargar el horario");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Horario horario)
        {
            if (ModelState.IsValid && horario.IdHorario > 0)
            {
                Update(horario);
                TempData["success"] = "El horario fue actualizado con éxito";
                return RedirectToAction("Index");
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
                HandleException(ex, "Error al cargar el horario");
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
                        Delete(horarioDb);
                        return RedirectToAction("Index");
                    }
                    TempData["error"] = "Error al eliminar el horario";
                    return View(horario);
                }
                catch (Exception ex)
                {
                    HandleException(ex, "Error al eliminar el horario");
                    return View(horario);
                }
            }
            TempData["error"] = "Error al eliminar el horario";
            return View(horario);
        }
    }
}
