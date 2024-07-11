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
    public class UsuariosController : BaseController<Usuario>
    {
        private readonly AplicacionDbContexto _aplicacionDb;
        public UsuariosController(AplicacionDbContexto aplicacionDb, ILogger<BaseController<Usuario>> logger)
            : base(aplicacionDb, logger)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                LoadReferenceData();
                var usuarios = GetAll();

                if (!String.IsNullOrEmpty(searchString))
                {
                    usuarios = usuarios.Where(u => u.NombreUsuario.Contains(searchString) || u.IdUsuario.ToString().Contains(searchString));
                }

                var listaUsuarios = usuarios.ToList();
                ViewData["CurrentFilter"] = searchString;
                return View(listaUsuarios);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar la lista de usuarios");
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            LoadReferenceData();
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Add(usuario);
                TempData["success"] = "El usuario fue agregado con éxito";
                return RedirectToAction("Index");
            }
            LoadReferenceData();
            return View(usuario);
        }

        public IActionResult Actualizar(int id)
        {
            try
            {
                var usuario = _aplicacionDb.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
                if (usuario == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                LoadReferenceData();
                return View(usuario);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar el usuario para actualizar");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(Usuario usuario)
        {
            if (ModelState.IsValid && usuario.IdUsuario > 0)
            {
                Update(usuario);
                TempData["success"] = "El usuario fue actualizado con éxito";
                return RedirectToAction("Index");
            }
            LoadReferenceData();
            return View(usuario);
        }

        public IActionResult Eliminar(int id)
        {
            try
            {
                var usuario = _aplicacionDb.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
                if (usuario == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                LoadReferenceData();
                return View(usuario);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar el usuario para eliminar");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(Usuario usuario)
        {
            if (ModelState.IsValid && usuario.IdUsuario > 0)
            {
                Delete(usuario);
                TempData["success"] = "El usuario fue eliminado con éxito";
                return RedirectToAction("Index");
            }
            LoadReferenceData();
            TempData["error"] = "El usuario no fue eliminado";
            return View(usuario);
        }
    }
}
