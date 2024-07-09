﻿using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;


namespace FISCAapp.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;
        public UsuariosController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                var usuarios = from u in _aplicacionDb.Usuarios
                               select u;

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
                TempData["error"] = "Error al cargar la lista de usuarios: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _aplicacionDb.Usuarios.Add(usuario);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "El usuario fue agregado con éxito";
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public IActionResult Actualizar(int id)
        {
            var usuario = _aplicacionDb.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
            if (usuario == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Actualizar(Usuario usuario)
        {
            if (ModelState.IsValid && usuario.IdUsuario > 0)
            {
                _aplicacionDb.Usuarios.Update(usuario);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "El usuario fue actualizado con éxito";
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public IActionResult Eliminar(int id)
        {
            var usuario = _aplicacionDb.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
            if (usuario == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Eliminar(Usuario usuario)
        {
            if (ModelState.IsValid && usuario.IdUsuario > 0)
            {
                _aplicacionDb.Usuarios.Remove(usuario);
                _aplicacionDb.SaveChanges();
                TempData["error"] = "El usuario fue eliminado con éxito";
                return RedirectToAction("Index");
            }
            TempData["error"] = "El usuario no fue eliminado";
            return View(usuario);
        }
    }
}
