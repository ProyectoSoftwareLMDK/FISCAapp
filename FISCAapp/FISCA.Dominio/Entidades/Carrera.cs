using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{

    public class Carrera
    {
        [Key]
        public int IdCarrera { get; set; }
        public string NombreCarrera { get; set; }
    }
}
