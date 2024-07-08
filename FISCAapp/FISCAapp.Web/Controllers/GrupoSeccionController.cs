using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FISCAapp.Web.Controllers
{
    [Authorize]
    public class GrupoSeccionController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;

        public GrupoSeccionController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                var grupos = from g in _aplicacionDb.Grupos
                             select g;

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
                TempData["error"] = "Error al cargar la lista de grupos: " + ex.Message;
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
                try
                {
                    _aplicacionDb.Grupos.Add(grupo);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "El grupo fue agregado con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al agregar el grupo: " + ex.Message;
                }
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
                TempData["error"] = "Error al cargar el grupo: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Grupo grupo)
        {
            if (ModelState.IsValid && grupo.IdGrupo > 0)
            {
                try
                {
                    _aplicacionDb.Grupos.Update(grupo);
                    _aplicacionDb.SaveChanges();
                    TempData["success"] = "El grupo fue actualizado con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al actualizar el grupo: " + ex.Message;
                }
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
                TempData["error"] = "Error al cargar el grupo: " + ex.Message;
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
                        _aplicacionDb.Grupos.Remove(grupoDb);
                        _aplicacionDb.SaveChanges();
                        TempData["success"] = "El grupo fue eliminado con éxito";
                        return RedirectToAction("Index");
                    }
                    TempData["error"] = "Error al eliminar el grupo";
                    return View(grupo);
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error al eliminar el grupo: " + ex.Message;
                    return View(grupo);
                }
            }
            TempData["error"] = "Error al eliminar el grupo";
            return View(grupo);
        }
    }
}
