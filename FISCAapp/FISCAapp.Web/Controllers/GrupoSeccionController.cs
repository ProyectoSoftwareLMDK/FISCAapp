using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;

namespace FISCAapp.Web.Controllers
{
    public class GrupoSeccionController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;
        public GrupoSeccionController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index()
        {
            var listaGrupos = _aplicacionDb.Grupos.ToList();
            return View(listaGrupos);
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
                _aplicacionDb.Grupos.Add(grupo);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "El grupo fue agregado con éxito";
                return RedirectToAction("Index");
            }
            return View(grupo);
        }

        public IActionResult Actualizar(int id)
        {
            var grupo = _aplicacionDb.Grupos.FirstOrDefault(g => g.IdGrupo == id);
            if (grupo == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(grupo);
        }

        [HttpPost]
        public IActionResult Actualizar(Grupo grupo)
        {
            if (ModelState.IsValid && grupo.IdGrupo > 0)
            {
                _aplicacionDb.Grupos.Update(grupo);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "El grupo fue actualizado con éxito";
                return RedirectToAction("Index");
            }
            return View(grupo);
        }

        public IActionResult Eliminar(int id)
        {
            var grupo = _aplicacionDb.Grupos.FirstOrDefault(g => g.IdGrupo == id);
            if (grupo == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(grupo);
        }

        [HttpPost]
        public IActionResult Eliminar(Grupo grupo)
        {
            if (ModelState.IsValid && grupo.IdGrupo > 0)
            {
                _aplicacionDb.Grupos.Remove(grupo);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "El grupo fue eliminado con éxito";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error al eliminar el grupo";
            return View(grupo);
        }
    }
}
