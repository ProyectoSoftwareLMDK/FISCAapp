using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    public class Evaluacion
    {
        [Key]
        public int IdEvaluacion { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        [Required]
        public int IdEstudiante { get; set; }

        [Required]
        public int IdAsignatura { get; set; }

        [Required]
        [StringLength(50)]
        public string Unidad { get; set; }

        [Required]
        [StringLength(50)]
        public string Tarea { get; set; }

        [Required]
        public int IdDocente { get; set; }

        [Required]
        public int Puntaje { get; set; }

        [Required]
        public DateTime FechaEvaluacion { get; set; }

    }
}
