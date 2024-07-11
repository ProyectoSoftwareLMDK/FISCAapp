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
    public class PlanEstudioController : BaseController<PlanEstudio>
    {
        private readonly AplicacionDbContexto _aplicacionDb;
        public PlanEstudioController(AplicacionDbContexto aplicacionDb, ILogger<BaseController<PlanEstudio>> logger)
            : base(aplicacionDb, logger)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                LoadReferenceData();
                var planes = GetAll();
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
                HandleException(ex, "Error al cargar la lista de planes de estudio");
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Crear()
        {
            LoadReferenceData();
            return View();
        }

        [HttpPost]
        public IActionResult Crear(PlanEstudio plan)
        {
            if (ModelState.IsValid)
            {
                Add(plan);
                return RedirectToAction("Index");
            }
            LoadReferenceData();
            return View(plan);
        }

        public IActionResult Editar(int id)
        {
            try
            {
                var plan = GetAll().FirstOrDefault(p => p.IdPlan == id);
                if (plan == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                LoadReferenceData();
                return View(plan);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar el plan de estudio para actualizar");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Editar(PlanEstudio plan)
        {
            if (ModelState.IsValid && plan.IdPlan > 0)
            {
                Update(plan);
                TempData["success"] = "Plan de estudio actualizado con éxito";
                return RedirectToAction("Index");
            }
            LoadReferenceData();
            return View(plan);
        }

        public IActionResult Eliminar(int id)
        {
            try
            {
                var plan = GetAll().FirstOrDefault(p => p.IdPlan == id);
                if (plan == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(plan);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar el plan de estudio para eliminar");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(PlanEstudio plan)
        {
            if (ModelState.IsValid && plan.IdPlan > 0)
            {
                Delete(plan);
                TempData["success"] = "Plan de estudio eliminado con éxito";
                return RedirectToAction("Index");
            }
            LoadReferenceData();
            return View(plan);
        }
    }
}
