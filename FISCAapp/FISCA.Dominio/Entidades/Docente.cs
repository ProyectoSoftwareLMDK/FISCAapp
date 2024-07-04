using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    public class Docente
    {
        [Key]
        public int IdDocente { get; set; }

        [Required]
        [StringLength(50)]
        public string NombresDocente { get; set; }

        [Required]
        [StringLength(50)]
        public string ApellidosDocente { get; set; }

        [Required]
        [StringLength(16)]
        public string CedulaDocente { get; set; }

        [Required]
        [StringLength(50)]
        public string CorreoDocente { get; set; }

        [Required]
        [StringLength(8)]
        public string CelularDocente { get; set; }

        [Required]
        [StringLength(8)]
        public string TelefonoDocente { get; set; }

        [Required]
        [StringLength(250)]
        public string DireccionDocente { get; set; }

        [Required]
        public int Estado { get; set; }

        [StringLength(100)]
        public string Foto { get; set; }
    }
}
