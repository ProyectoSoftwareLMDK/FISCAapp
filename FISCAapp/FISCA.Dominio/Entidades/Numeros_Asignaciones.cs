using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    public class Numeros_Asignaciones
    {
        [Key]
        public int IdNumerosAsignaciones { get; set; }
        public int NumeroAsignado { get; set; }
        public int IdDocente { get; set; }
    }
}
