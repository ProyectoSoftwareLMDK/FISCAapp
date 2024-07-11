using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace FISCAapp.Web.Controllers
{
    public class DocenteController : BaseController<Docente>
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public DocenteController(AplicacionDbContexto aplicacionDb, ILogger<BaseController<Docente>> logger)
            : base(aplicacionDb, logger)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                
                var docentes = GetAll();

                if (!String.IsNullOrEmpty(searchString))
                {
                    docentes = docentes.Where(d => d.NombresDocente.Contains(searchString) || d.CedulaDocente.Contains(searchString));
                }

                var listaDocentes = docentes.ToList();
                ViewData["CurrentFilter"] = searchString;
                return View(listaDocentes);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar la lista de docentes");
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Docente docente)
        {
            if (ModelState.IsValid)
            {
                Add(docente);
                TempData["success"] = "El docente fue agregado con éxito";
                return RedirectToAction("Index");
            }
            
            return View(docente);
        }

        public IActionResult Actualizar(int id)
        {
            try
            {
                var docente = _aplicacionDb.Docentes.FirstOrDefault(d => d.IdDocente == id);
                if (docente == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                
                return View(docente);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar el docente");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Docente docente)
        {
            if (ModelState.IsValid && docente.IdDocente > 0)
            {
                Update(docente);
                TempData["success"] = "El docente fue actualizado con éxito";
                return RedirectToAction("Index");
            }
           
            return View(docente);
        }

        public IActionResult Eliminar(int id)
        {
            try
            {
                var docente = _aplicacionDb.Docentes.FirstOrDefault(d => d.IdDocente == id);
                if (docente == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(docente);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar el docente");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(Docente docente)
        {
            if (ModelState.IsValid && docente.IdDocente > 0)
            {
                try
                {
                    var docenteDb = _aplicacionDb.Docentes.FirstOrDefault(d => d.IdDocente == docente.IdDocente);
                    if (docenteDb != null)
                    {
                        Delete(docenteDb);
                        TempData["success"] = "El docente fue eliminado con éxito";
                        return RedirectToAction("Index");
                    }
                    TempData["error"] = "Error al eliminar el docente";
                    return View(docente);
                }
                catch (Exception ex)
                {
                    HandleException(ex, "Error al eliminar el docente");
                    return View(docente);
                }
            }

            TempData["error"] = "Error al eliminar el docente";
            return View(docente);
        }
    }
}
