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
        public IActionResult IndexMaterialDidactico()
        {
            var listaMaterialDidactico = _aplicacionDb.materialDidacticos.ToList();
            return View(listaMaterialDidactico);
        }
        public IActionResult IndexMensajes()
        {
            var listaMensajes = _aplicacionDb.mensajes.ToList();
            return View(listaMensajes);
        }
        public IActionResult IndexNiveles()
        {
            var listaNiveles = _aplicacionDb.niveles.ToList();
            return View(listaNiveles);
        }
        public IActionResult IndexNumerosAsignaturas()
        {
            var listaNumerosAsig = _aplicacionDb.numeros_Asignaciones.ToList();
            return View(listaNumerosAsig);
        }

        //KENYI
        public IActionResult Asignacion()
        {
            var listaAsignacion = _aplicacionDb.asignaciones.ToList();
            return View(listaAsignacion);
        }
        public IActionResult Asignatura()
        {
            var listaAsignatura = _aplicacionDb.asignaturas.ToList();
            return View(listaAsignatura);
        }
        public IActionResult Carrera()
        {
            var listaCarrera = _aplicacionDb.carreras.ToList();
            return View(listaCarrera);
        }
        public IActionResult Cuatrimestre()
        {
            var listaCuatrimestre = _aplicacionDb.cuatrimestres.ToList();
            return View(listaCuatrimestre);
        }
        public IActionResult Docente()
        {
            var listaDocente = _aplicacionDb.docentes.ToList();
            return View(listaDocente);
        }
    }
}
