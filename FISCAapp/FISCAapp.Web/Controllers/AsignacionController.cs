using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FISCAapp.Web.Controllers
{
    public class AsignacionController : Controller
    {
        private readonly AplicacionDbContexto _contexto;

        public AsignacionController(AplicacionDbContexto contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            var asignaciones = _contexto.Asignaciones.ToList();
            return View(asignaciones);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                _contexto.Asignaciones.Add(asignacion);
                _contexto.SaveChanges();
                TempData["success"] = "La asignación fue agregada con éxito";
                return RedirectToAction("Index");
            }
            return View(asignacion);
        }

        public IActionResult Actualizar(int id)
        {
            var asignacion = _contexto.Asignaciones.FirstOrDefault(a => a.IdAsignacion == id);
            if (asignacion == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(asignacion);
        }

        [HttpPost]
        public IActionResult Actualizar(Asignacion asignacion)
        {
            if (ModelState.IsValid && asignacion.IdAsignacion > 0)
            {
                _contexto.Asignaciones.Update(asignacion);
                _contexto.SaveChanges();
                TempData["success"] = "La asignación fue actualizada con éxito";
                return RedirectToAction("Index");
            }
            return View(asignacion);
        }

        public IActionResult Eliminar(int id)
        {
            var asignacion = _contexto.Asignaciones.FirstOrDefault(a => a.IdAsignacion == id);
            if (asignacion == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(asignacion);
        }

        [HttpPost]
        public IActionResult Eliminar(Asignacion asignacion)
        {
            if (ModelState.IsValid && asignacion.IdAsignacion > 0)
            {
                _contexto.Asignaciones.Remove(asignacion);
                _contexto.SaveChanges();
                TempData["success"] = "La asignación fue eliminada con éxito";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error al eliminar la asignación";
            return View(asignacion);
        }
    }
}
