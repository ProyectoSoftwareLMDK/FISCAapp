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
    }
}
