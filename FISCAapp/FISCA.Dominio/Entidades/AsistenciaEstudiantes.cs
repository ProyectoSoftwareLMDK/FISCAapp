using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FISCA.Dominio.Entidades
{
    [Table("AsistenciaEstudiantes")]
    public class AsistenciaEstudiantes
    {
        [Key]
        public int IdAsistencia { get; set; }

        public int IdEstudiante { get; set; }
        public int IdAsignacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}
