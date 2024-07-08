using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FISCA.Dominio.Entidades
{
    public class Estudiante
    {
        [Key]
        public int IdEstudiante { get; set; }

        [Required]
        [StringLength(10)]
        [Column("CarnetEstudiante")]
        public string CarnetEstudiante { get; set; }

        [Required]
        [StringLength(50)]
        [Column("NombresEstudiante")]
        public string NombresEstudiante { get; set; }

        [Required]
        [StringLength(50)]
        [Column("ApellidosEstudiante")]
        public string ApellidosEstudiante { get; set; }

        [Required]
        [StringLength(16)]
        [Column("CedulaEstudiante")]
        public string CedulaEstudiante { get; set; }

        [Required]
        [StringLength(50)]
        [Column("CorreoEstudiante")]
        public string CorreoEstudiante { get; set; }

        [Required]
        [StringLength(8)]
        [Column("CelularEstudiante")]
        public string CelularEstudiante { get; set; }

        [Required]
        [StringLength(8)]
        [Column("TelefonoEstudiante")]
        public string TelefonoEstudiante { get; set; }

        [Required]
        [StringLength(250)]
        [Column("DireccionEstudiante")]
        public string DireccionEstudiante { get; set; }

        [Required]
        [Column("Estado")]
        public int Estado { get; set; }

        public int? IdGrupo { get; set; }

        [StringLength(100)]
        [Column("Foto")]
        public string Foto { get; set; }

    }
}
