﻿using FISCA.Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;


namespace FISCAapp.WEB.Controllers
{
    public class ProyectoController : Controller
    {
        private readonly AplicacionDbContexto _aplicacionDb;
        public ProyectoController(AplicacionDbContexto aplicacionDb)
        {
            _aplicacionDb = aplicacionDb;
        }
        //Incripciones
        public IActionResult Index()
        {
            var listaIncripciones = _aplicacionDb.InscripcionesAsignaturas.ToList();
            return View(listaIncripciones);
        }
        public IActionResult Cuatrimestre()
        {
            var listaCuatrimestre = _aplicacionDb.Cuatrimestres.ToList();
            return View(listaCuatrimestre);
        }
          public IActionResult Carrera()
            {
          var listaCarrera = _aplicacionDb.Carreras.ToList();
               return View(listaCarrera);
         } 
        public IActionResult Grupo()
        {
            var listaGrupo = _aplicacionDb.Grupos.ToList();
            return View(listaGrupo);
        }
        public IActionResult Horario()
        {
            var listaHorarios = _aplicacionDb.Horarios.ToList();
            return View(listaHorarios);
        }
        public IActionResult Turno()
        {
            var listaTurnos = _aplicacionDb.Turnos.ToList();
            return View(listaTurnos);
        }
        public IActionResult Estudiante()
        {
            var listaEstudiante = _aplicacionDb.Estudiantes.ToList();
            return View(listaEstudiante);
        } 
        public IActionResult Docente()
        {
            var listaDocente = _aplicacionDb.Docentes.ToList();
            return View(listaDocente);
        }
        public IActionResult Niveles()
        {
            var listaNiveles = _aplicacionDb.Niveles.ToList();
            return View(listaNiveles);
        }
        public IActionResult NumerosAsignaturas()
        {
            var listaNumerosAsignaciones = _aplicacionDb.NumerosAsignaciones.ToList();
            return View(listaNumerosAsignaciones);
        }
        public IActionResult Usuario()
        {
            var listaUsuarios = _aplicacionDb.Usuarios.ToList();
            return View(listaUsuarios);
        }
        public IActionResult Asignatura()
        {
            var listaAsignatura = _aplicacionDb.Asignaturas.ToList();
            return View(listaAsignatura);
        }
        public IActionResult Asignacion()
        {
            var listaAsignaciones = _aplicacionDb.Asignaciones.ToList();
            return View(listaAsignaciones);
        }
        public IActionResult PlanEstudios()
        {
            var listaPlanEstudio = _aplicacionDb.PlanEstudios.ToList();
            return View(listaPlanEstudio);
        }
    }
}
