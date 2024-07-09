using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    public class Usuario
    {
        [Key]
        public short IdUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(150)]
        public string PassUsuario { get; set; }

        [Required]
        public int NivelUsuario { get; set; }

        [Required]
        public int Codigo { get; set; }

    }
}
