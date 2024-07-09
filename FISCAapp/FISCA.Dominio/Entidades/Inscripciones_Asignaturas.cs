using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    
    public class Inscripciones_Asignaturas
    {
        [Key]

        public int IdInscripcion { get; set; }
        public int IdAsignatura { get; set; }
        public int IdEstudiante { get; set; }
        public DateTime? FechaInscripcion { get; set; }
        public string? Observaciones { get; set; }

    }
}
