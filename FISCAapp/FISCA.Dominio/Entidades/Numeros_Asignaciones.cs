using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    [Table("Numeros_Asignaciones")]
    public class Numeros_Asignaciones
    {
        [Key]
        public int IdNumerosAsignaciones { get; set; }
        public int NumeroAsignado { get; set; }
        public int IdDocente { get; set; }
    }
}
