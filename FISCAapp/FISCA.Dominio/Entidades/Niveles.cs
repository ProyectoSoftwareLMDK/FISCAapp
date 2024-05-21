using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    public class Niveles
    {
    
        [Key] public int IdNivel { get; set; }
        public string? NombreNivel { get; set; }

    }
}
