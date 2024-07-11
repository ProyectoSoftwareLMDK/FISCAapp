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
    public class AsignaturaController : BaseController <Asignatura>
    {
        private readonly AplicacionDbContexto _aplicacionDb;
        public AsignaturaController(AplicacionDbContexto aplicacionDb, ILogger<BaseController<Asignatura>> logger)
            : base(aplicacionDb, logger)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                LoadReferenceData();
                var asignaturas = GetAll();

                if (!String.IsNullOrEmpty(searchString))
                {
                    asignaturas = asignaturas.Where(a => a.NombreAsignatura.Contains(searchString));
                }

                var listaAsignaturas = asignaturas.ToList();
                ViewData["CurrentFilter"] = searchString;
                return View(listaAsignaturas);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar la lista de asignaturas");
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            LoadReferenceData();
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                Add(asignatura);
                return RedirectToAction("Index");
            }

            LoadReferenceData();
            return View(asignatura);
        }

        public IActionResult Actualizar(int idAsignatura)
        {
            try
            {
                var asignatura = _aplicacionDb.Set<Asignatura>().FirstOrDefault(a => a.IdAsignatura == idAsignatura);
                if (asignatura == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                LoadReferenceData();
                return View(asignatura);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar la asignatura para actualizar");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Asignatura asignatura)
        {
            if (ModelState.IsValid && asignatura.IdAsignatura > 0)
            {
                Update(asignatura);
                return RedirectToAction("Index");
            }

            LoadReferenceData();
            return View(asignatura);
        }

        public IActionResult Eliminar(int idAsignatura)
        {
            try
            {
                var asignatura = _aplicacionDb.Set<Asignatura>().FirstOrDefault(a => a.IdAsignatura == idAsignatura);
                if (asignatura == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                LoadReferenceData();
                return View(asignatura);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar la asignatura para eliminar");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(Asignatura asignatura)
        {
            Delete(asignatura); // Utiliza el método Delete definido en BaseController
            return RedirectToAction("Index");
        }
    }
}
