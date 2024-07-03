using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    public class Horario
    {
        [Key]
        public int IdHorario { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreHorario { get; set; }
    }
}
