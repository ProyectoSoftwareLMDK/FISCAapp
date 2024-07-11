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
    public class GrupoSeccionController : BaseController<Grupo>
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public GrupoSeccionController(AplicacionDbContexto aplicacionDb, ILogger<BaseController<Grupo>> logger)
            : base(aplicacionDb, logger)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                
                var grupos = GetAll();

                if (!String.IsNullOrEmpty(searchString))
                {
                    grupos = grupos.Where(g => g.NombreGrupo.Contains(searchString));
                }

                var listaGrupos = grupos.ToList();
                ViewData["CurrentFilter"] = searchString;
                return View(listaGrupos);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar la lista de grupos");
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Grupo grupo)
        {
            if (grupo.NumeroGrupo == grupo.NombreGrupo)
            {
                ModelState.AddModelError("NumeroGrupo", "El número de grupo no puede ser igual al nombre del grupo");
            }

            if (ModelState.IsValid)
            {
                Add(grupo);
                TempData["success"] = "El grupo fue agregado con éxito";
                return RedirectToAction("Index");
            }
            
            return View(grupo);
        }

        public IActionResult Actualizar(int id)
        {
            try
            {
                var grupo = _aplicacionDb.Grupos.FirstOrDefault(g => g.IdGrupo == id);
                if (grupo == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                
                return View(grupo);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar el grupo");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Grupo grupo)
        {
            if (ModelState.IsValid && grupo.IdGrupo > 0)
            {
                Update(grupo);
                TempData["success"] = "El grupo fue actualizado con éxito";
                return RedirectToAction("Index");
            }
            
            return View(grupo);
        }

        public IActionResult Eliminar(int id)
        {
            try
            {
                var grupo = _aplicacionDb.Grupos.FirstOrDefault(g => g.IdGrupo == id);
                if (grupo == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(grupo);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar el grupo");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(Grupo grupo)
        {
            if (ModelState.IsValid && grupo.IdGrupo > 0)
            {
                try
                {
                    var grupoDb = _aplicacionDb.Grupos.FirstOrDefault(g => g.IdGrupo == grupo.IdGrupo);
                    if (grupoDb != null)
                    {
                        Delete(grupoDb);
                        return RedirectToAction("Index");
                    }
                    return View(grupo);
                }
                catch (Exception ex)
                {
                    HandleException(ex, "Error al eliminar el grupo");
                    return View(grupo);
                }
            }
            return View(grupo);
        }
    }
}
