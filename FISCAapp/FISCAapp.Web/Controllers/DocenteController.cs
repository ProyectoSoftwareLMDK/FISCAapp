﻿using FISCA.Dominio.Entidades;
using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;


namespace FISCAapp.Web.Controllers
{
    public class DocenteController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;
        public DocenteController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                var docentes = from d in _aplicacionDb.Docentes
                               select d;

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
                TempData["error"] = "Error al cargar la lista de docentes: " + ex.Message;
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
                _aplicacionDb.Docentes.Add(docente);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "El docente fue agregado con éxito";
                return RedirectToAction("Index");
            }
            return View(docente);
        }

        public IActionResult Actualizar(int id)
        {
            var docente = _aplicacionDb.Docentes.FirstOrDefault(d => d.IdDocente == id);
            if (docente == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(docente);
        }

        [HttpPost]
        public IActionResult Actualizar(Docente docente)
        {
            if (ModelState.IsValid && docente.IdDocente > 0)
            {
                _aplicacionDb.Docentes.Update(docente);
                _aplicacionDb.SaveChanges();
                TempData["success"] = "El docente fue actualizado con éxito";
                return RedirectToAction("Index");
            }
            return View(docente);
        }

        public IActionResult Eliminar(int id)
        {
            var docente = _aplicacionDb.Docentes.FirstOrDefault(d => d.IdDocente == id);
            if (docente == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(docente);
        }

        [HttpPost]
        public IActionResult Eliminar(Docente docente)
        {
            if (ModelState.IsValid && docente.IdDocente > 0)
            {
                _aplicacionDb.Docentes.Remove(docente);
                _aplicacionDb.SaveChanges();
                TempData["error"] = "El docente fue eliminado con éxito";
                return RedirectToAction("Index");
            }
            TempData["error"] = "El docente no fue eliminado";
            return View(docente);
        }
    }
}