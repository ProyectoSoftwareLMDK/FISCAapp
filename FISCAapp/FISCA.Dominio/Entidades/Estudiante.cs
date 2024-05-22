using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    public class Estudiante
    {
        [Key]
        public int IdEstudiante { get; set; }

        [Required]
        [StringLength(10)]
        public string CarnetEstudiante { get; set; }

        [Required]
        [StringLength(50)]
        public string NombresEstudiante { get; set; }

        [Required]
        [StringLength(50)]
        public string ApellidosEstudiante { get; set; }

        [Required]
        [StringLength(16)]
        public string CedulaEstudiante { get; set; }

        [Required]
        [StringLength(50)]
        public string CorreoEstudiante { get; set; }

        [Required]
        [StringLength(8)]
        public string CelularEstudiante { get; set; }

        [Required]
        [StringLength(8)]
        public string TelefonoEstudiante { get; set; }

        [Required]
        [StringLength(250)]
        public string DireccionEstudiante { get; set; }

        [Required]
        public int Estado { get; set; }

        public int? IdGrupo { get; set; }

        [StringLength(100)]
        public string Foto { get; set; }

    }
}
