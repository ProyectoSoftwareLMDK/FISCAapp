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
    public class NumerosAsignaturasController : BaseController<Numeros_Asignaciones>
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public NumerosAsignaturasController(AplicacionDbContexto aplicacionDb, ILogger<BaseController<Numeros_Asignaciones>> logger)
            : base(aplicacionDb, logger)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                LoadReferenceData();
                var numerosAsignaciones = GetAll();

                if (!String.IsNullOrEmpty(searchString))
                {
                    numerosAsignaciones = numerosAsignaciones.Where(n => n.NumeroAsignado.ToString().Contains(searchString));
                }

                var listaNumeroAsignacion = numerosAsignaciones.ToList();
                ViewData["CurrentFilter"] = searchString;
                return View(listaNumeroAsignacion);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar la lista de números de asignación");
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            LoadReferenceData();
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Numeros_Asignaciones numeroAsignacion)
        {
            if (ModelState.IsValid)
            {
                Add(numeroAsignacion);
                TempData["success"] = "Los datos fueron agregados con éxito";
                return RedirectToAction("Index");
            }

            LoadReferenceData();
            return View(numeroAsignacion);
        }

        public IActionResult Actualizar(int id)
        {
            try
            {
                var numeroAsignacion = _aplicacionDb.NumerosAsignaciones.FirstOrDefault(n => n.IdNumerosAsignaciones == id);
                if (numeroAsignacion == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                LoadReferenceData();
                return View(numeroAsignacion);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar el número de asignación para actualizar");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Numeros_Asignaciones numeroAsignacion)
        {
            if (ModelState.IsValid && numeroAsignacion.IdNumerosAsignaciones > 0)
            {
                Update(numeroAsignacion);
                TempData["success"] = "Los datos fueron actualizados con éxito";
                return RedirectToAction("Index");
            }

            LoadReferenceData();
            return View(numeroAsignacion);
        }

        public IActionResult Eliminar(int id)
        {
            try
            {
                var numeroAsignacion = _aplicacionDb.NumerosAsignaciones.FirstOrDefault(n => n.IdNumerosAsignaciones == id);
                if (numeroAsignacion == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(numeroAsignacion);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar el número de asignación para eliminar");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(Numeros_Asignaciones numeroAsignacion)
        {
            if (ModelState.IsValid && numeroAsignacion.IdNumerosAsignaciones > 0)
            {
                Delete(numeroAsignacion);
                TempData["success"] = "Los datos fueron eliminados con éxito";
                return RedirectToAction("Index");
            }

            TempData["error"] = "Error al eliminar el número de asignación";
            return View(numeroAsignacion);
        }
    }
}
