using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    public class Cuatrimestre
    {
        [Key] public int IdCuatrimestre { get; set; }
        public string? NombreCuatrimestre { get; set; }
    }
}
