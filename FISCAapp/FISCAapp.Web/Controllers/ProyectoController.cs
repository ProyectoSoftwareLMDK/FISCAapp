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
    }
}
