using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    public class Turno
    {
        [Key]
        public int IdTurno { get; set; }
        [Required]
        [StringLength(50)]
        public string NombreTurno { get; set; }
    }
}
