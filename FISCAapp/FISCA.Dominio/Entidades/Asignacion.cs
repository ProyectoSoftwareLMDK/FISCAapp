using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    public class Asignacion
    {
        [Key] public int IdAsignacion { get; set; }
        public string? Descripcion { get; set; }
        public int IdDocente { get; set; }
        public int IdAsignatura { get; set; }
        public int IdGrupo { get; set; }
        public int IdTurno { get; set; }
        public int IdHorario { get; set; }
        public string? Estado { get; set; }
        public int NumeroAsignacion { get; set; }
    }
}
