using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{

    public class Nivel
    {
        [Key]
        public int IdNivel { get; set; }
        public string NombreNivel { get; set; }

    }
}
