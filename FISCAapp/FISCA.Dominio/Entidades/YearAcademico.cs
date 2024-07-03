using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FISCA.Dominio.Entidades
{
    public class YearAcademico
    {
        [Key]
        public int IdYearAcademico { get; set; }
         public string NombreYear { get; set; }
    }
}
