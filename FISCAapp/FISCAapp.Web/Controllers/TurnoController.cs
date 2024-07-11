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
    public class TurnosController : BaseController<Turno>
    {
        private readonly AplicacionDbContexto _aplicacionDb;
        public TurnosController(AplicacionDbContexto aplicacionDb, ILogger<BaseController<Turno>> logger)
            : base(aplicacionDb, logger)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                
                var turnos = GetAll();

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
                HandleException(ex, "Error al cargar la lista de turnos");
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
                Add(turno);
                TempData["success"] = "El turno fue agregado con éxito";
                return RedirectToAction("Index");
            }
            
            return View(turno);
        }

        public IActionResult Actualizar(int id)
        {
            try
            {
                var turno = GetAll().FirstOrDefault(t => t.IdTurno == id);
                if (turno == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                
                return View(turno);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar el turno para actualizar");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Turno turno)
        {
            if (ModelState.IsValid && turno.IdTurno > 0)
            {
                Update(turno);
                TempData["success"] = "El turno fue actualizado con éxito";
                return RedirectToAction("Index");
            }
            
            return View(turno);
        }

        public IActionResult Eliminar(int id)
        {
            try
            {
                var turno = GetAll().FirstOrDefault(t => t.IdTurno == id);
                if (turno == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                
                return View(turno);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar el turno para eliminar");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(Turno turno)
        {
            if (ModelState.IsValid && turno.IdTurno > 0)
            {
                Delete(turno);
                TempData["success"] = "El turno fue eliminado con éxito";
                return RedirectToAction("Index");
            }
            
            TempData["error"] = "El turno no fue eliminado";
            return View(turno);
        }
    }
}
