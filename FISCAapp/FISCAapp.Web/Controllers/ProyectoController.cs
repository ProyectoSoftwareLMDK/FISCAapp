using FISCA.Infraestructura.Data;
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
            var listaIncripciones = _aplicacionDb.inscripcionesAsignaturas.ToList();
            return View(listaIncripciones);
        }
        public IActionResult YearAcademico() {
            var listaYearAcademico = _aplicacionDb.yearAcademicos.ToList();
            return View(listaYearAcademico);
        }
        public IActionResult Cuatrimestre()
        {
            var listaCuatrimestre = _aplicacionDb.cuatrimestres.ToList();
            return View(listaCuatrimestre);
        }
        public IActionResult Carrera()
        {
            var listaCarrera = _aplicacionDb.carreras.ToList();
            return View(listaCarrera);
        }
        public IActionResult Grupo()
        {
            var listaGrupo = _aplicacionDb.grupos.ToList();
            return View(listaGrupo);
        }
        public IActionResult Horario()
        {
            var listaHorarios = _aplicacionDb.horarios.ToList();
            return View(listaHorarios);
        }
        public IActionResult Turno()
        {
            var listaTurnos = _aplicacionDb.turnos.ToList();
            return View(listaTurnos);
        }
        public IActionResult Estudiante()
        {
            var listaEstudiante = _aplicacionDb.Estudiantes.ToList();
            return View(listaEstudiante);
        } 
        public IActionResult Docente()
        {
            var listaDocente = _aplicacionDb.docentes.ToList();
            return View(listaDocente);
        }
        public IActionResult MaterialDidactico()
        {
            var listaMaterialDidactico = _aplicacionDb.materialDidacticos.ToList();
            return View(listaMaterialDidactico);
        }
        public IActionResult Mensajes()
        {
            var listaMensajes = _aplicacionDb.mensajes.ToList();
            return View(listaMensajes);
        }
        public IActionResult Niveles()
        {
            var listaNiveles = _aplicacionDb.niveles.ToList();
            return View(listaNiveles);
        }
        public IActionResult NumerosAsignaturas()
        {
            var listaNumerosAsignaciones = _aplicacionDb.numeros_Asignaciones.ToList();
            return View(listaNumerosAsignaciones);
        }
        public IActionResult Usuario()
        {
            var listaUsuarios = _aplicacionDb.usuarios.ToList();
            return View(listaUsuarios);
        }
        public IActionResult Asignatura()
        {
            var listaAsignatura = _aplicacionDb.asignaturas.ToList();
            return View(listaAsignatura);
        }
        public IActionResult EntregaTarea()
        {
            var listaEntregaTarea = _aplicacionDb.entregaTareas.ToList();
            return View(listaEntregaTarea);
        }
        public IActionResult PlanificacionTarea()
        {
            var listaPlanificacionTarea = _aplicacionDb.planificacionTareas.ToList();
            return View(listaPlanificacionTarea);
        }
        public IActionResult Evaluacion()
        {
            var listaEvaluaciones = _aplicacionDb.evaluaciones.ToList();
            return View(listaEvaluaciones);
        }
        public IActionResult Asignacion()
        {
            var listaAsignaciones = _aplicacionDb.asignaciones.ToList();
            return View(listaAsignaciones);
        }
        public IActionResult PlanEstudios()
        {
            var listaPlanEstudio = _aplicacionDb.planEstudios.ToList();
            return View(listaPlanEstudio);
        }
    }
}
