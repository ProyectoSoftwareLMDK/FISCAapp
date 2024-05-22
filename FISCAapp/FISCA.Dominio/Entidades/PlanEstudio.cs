using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    public class PlanEstudio
    {
        [Key]
        public int IdPlan { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        [Required]
        public int IdCarrera { get; set; }

        [Required]
        public int CantidadAsignaturas { get; set; }
    }
}
