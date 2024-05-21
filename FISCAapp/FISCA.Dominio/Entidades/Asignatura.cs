using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    public class Asignatura
    {
        [Key] public int IdAsignatura { get; set; }
        public string? NombreAsignatura { get; set; }
        public int IdCarrera { get; set; }
        public int IdGrupo { get; set; }
        public int IdCuatrimestre { get; set; }
    }
}
