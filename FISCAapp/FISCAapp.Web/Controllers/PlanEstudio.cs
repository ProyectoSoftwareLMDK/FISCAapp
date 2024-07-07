using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FISCAapp.Web.Controllers
{
    public class PlanEstudioController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public PlanEstudioController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index()
        {
            var listaPlanes = _aplicacionDb.PlanEstudios.ToList();
            return View(listaPlanes);
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
                _aplicacionDb.PlanEstudios.Add(plan);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "Plan de estudio creado con éxito";
                return RedirectToAction("Index");
            }
            return View(plan);
        }

        public IActionResult Editar(int id)
        {
            var plan = _aplicacionDb.PlanEstudios.FirstOrDefault(p => p.IdPlan == id);
            if (plan == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(plan);
        }

        [HttpPost]
        public IActionResult Editar(PlanEstudio plan)
        {
            if (ModelState.IsValid)
            {
                _aplicacionDb.PlanEstudios.Update(plan);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "Plan de estudio actualizado con éxito";
                return RedirectToAction("Index");
            }
            return View(plan);
        }

        public IActionResult Eliminar(int id)
        {
            var plan = _aplicacionDb.PlanEstudios.FirstOrDefault(p => p.IdPlan == id);
            if (plan == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(plan);
        }

        [HttpPost]
        public IActionResult Eliminar(PlanEstudio plan)
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
    }
}
