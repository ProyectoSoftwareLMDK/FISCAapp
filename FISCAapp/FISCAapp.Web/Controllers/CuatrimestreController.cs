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
    public class CuatrimestreController : BaseController<Cuatrimestre>
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public CuatrimestreController(AplicacionDbContexto aplicacionDb, ILogger<BaseController<Cuatrimestre>> logger)
            : base(aplicacionDb, logger)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                
                var cuatrimestres = GetAll();

                if (!String.IsNullOrEmpty(searchString))
                {
                    cuatrimestres = cuatrimestres.Where(c => c.NombreCuatrimestre.Contains(searchString));
                }

                var listaCuatrimestres = cuatrimestres.ToList();
                ViewData["CurrentFilter"] = searchString;
                return View(listaCuatrimestres);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar la lista de cuatrimestres");
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Cuatrimestre cuatrimestre)
        {
            if (string.IsNullOrWhiteSpace(cuatrimestre.NombreCuatrimestre))
            {
                ModelState.AddModelError("NombreCuatrimestre", "El nombre del cuatrimestre es obligatorio.");
            }

            if (ModelState.IsValid)
            {
                Add(cuatrimestre);
                TempData["success"] = "El cuatrimestre fue agregado con éxito";
                return RedirectToAction("Index");
            }

            
            return View(cuatrimestre);
        }

        public IActionResult Actualizar(int id)
        {
            try
            {
                var cuatrimestre = _aplicacionDb.Cuatrimestres.FirstOrDefault(c => c.IdCuatrimestre == id);
                if (cuatrimestre == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                
                return View(cuatrimestre);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar el cuatrimestre");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Cuatrimestre cuatrimestre)
        {
            if (ModelState.IsValid && cuatrimestre.IdCuatrimestre > 0)
            {
                Update(cuatrimestre);
                TempData["success"] = "El cuatrimestre fue actualizado con éxito";
                return RedirectToAction("Index");
            }

            
            return View(cuatrimestre);
        }

        public IActionResult Eliminar(int id)
        {
            try
            {
                var cuatrimestre = _aplicacionDb.Cuatrimestres.FirstOrDefault(c => c.IdCuatrimestre == id);
                if (cuatrimestre == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(cuatrimestre);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar el cuatrimestre");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(Cuatrimestre cuatrimestre)
        {
            if (ModelState.IsValid && cuatrimestre.IdCuatrimestre > 0)
            {
                try
                {
                    var cuatrimestreDb = _aplicacionDb.Cuatrimestres.FirstOrDefault(c => c.IdCuatrimestre == cuatrimestre.IdCuatrimestre);
                    if (cuatrimestreDb != null)
                    {
                        Delete(cuatrimestreDb);
                        TempData["success"] = "El cuatrimestre fue eliminado con éxito";
                        return RedirectToAction("Index");
                    }
                    TempData["error"] = "Error al eliminar el cuatrimestre";
                    return View(cuatrimestre);
                }
                catch (Exception ex)
                {
                    HandleException(ex, "Error al eliminar el cuatrimestre");
                    return View(cuatrimestre);
                }
            }

            TempData["error"] = "Error al eliminar el cuatrimestre";
            return View(cuatrimestre);
        }
    }
}
