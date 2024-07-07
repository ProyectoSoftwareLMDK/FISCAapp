using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    public class Asignacion
    {
        [Key]
        public int IdAsignacion { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        [Required]
        public int IdDocente { get; set; }

        [Required]
        public int IdAsignatura { get; set; }

        [Required]
        public int IdGrupo { get; set; }

        [Required]
        public int IdTurno { get; set; }

        [Required]
        public int IdHorario { get; set; }

        [Required]
        [StringLength(11)]
        public string Estado { get; set; }

        [Required]
        public int NumeroAsignacion { get; set; }

        
    }
}
