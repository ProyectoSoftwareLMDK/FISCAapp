using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FISCAapp.Web.Controllers
{
    [Authorize]
    public class PlanEstudioController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public PlanEstudioController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                var planes = from p in _aplicacionDb.PlanEstudios
                             select p;

                if (!String.IsNullOrEmpty(searchString))
                {
                    planes = planes.Where(p => p.Descripcion.Contains(searchString));
                }

                var listaPlanes = planes.ToList();
                ViewData["CurrentFilter"] = searchString;
                return View(listaPlanes);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar la lista de planes de estudio: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(PlanEstudio plan)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _aplicacionDb.PlanEstudios.Add(plan);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "Plan de estudio creado con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al agregar el plan de estudio: " + ex.Message;
                }
            }
            return View(plan);
        }

        public IActionResult Editar(int id)
        {
            try
            {
                var plan = _aplicacionDb.PlanEstudios.FirstOrDefault(p => p.IdPlan == id);
                if (plan == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(plan);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar el plan de estudio: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Editar(PlanEstudio plan)
        {
            if (ModelState.IsValid && plan.IdPlan > 0)
            {
                try
                {
                    _aplicacionDb.PlanEstudios.Update(plan);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "Plan de estudio actualizado con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al actualizar el plan de estudio: " + ex.Message;
                }
            }
            return View(plan);
        }

        public IActionResult Eliminar(int id)
        {
            try
            {
                var plan = _aplicacionDb.PlanEstudios.FirstOrDefault(p => p.IdPlan == id);
                if (plan == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(plan);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al cargar el plan de estudio: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(PlanEstudio plan)
        {
            if (ModelState.IsValid && plan.IdPlan > 0)
            {
                try
                {
                    var planDb = _aplicacionDb.PlanEstudios.FirstOrDefault(p => p.IdPlan == plan.IdPlan);
                    if (planDb != null)
                    {
                        _aplicacionDb.PlanEstudios.Remove(planDb);
                        _aplicacionDb.SaveChanges();
                        TempData["success"] = "Plan de estudio eliminado con éxito";
                        return RedirectToAction("Index");
                    }
                    TempData["error"] = "Error al eliminar el plan de estudio";
                    return View(plan);
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al eliminar el plan de estudio: " + ex.Message;
                    return View(plan);
                }
            }
            TempData["error"] = "Error al eliminar el plan de estudio";
            return View(plan);
        }
    }
}
