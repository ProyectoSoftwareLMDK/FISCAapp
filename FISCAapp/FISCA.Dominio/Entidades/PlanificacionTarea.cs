using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    public class PlanificacionTarea
    {
        [Key]
        public int IdPlanificacion { get; set; }

        [Required]
        public int IdDocente { get; set; }

        [Required]
        public int IdNumeroAsignacion { get; set; }

        [Required]
        public int IdAsignatura { get; set; }

        [Required]
        [StringLength(50)]
        public string Unidad { get; set; }

        [Required]
        [StringLength(200)]
        public string DescripcionUnidad { get; set; }

        [Required]
        [StringLength(50)]
        public string Tarea { get; set; }

        [Required]
        [StringLength(200)]
        public string DescripcionTarea { get; set; }

        [Required]
        public DateTime FechaPublicacion { get; set; }

        [Required]
        public DateTime FechaPresentacion { get; set; }

        [Required]
        public int CodigoTarea { get; set; }

    }
}
