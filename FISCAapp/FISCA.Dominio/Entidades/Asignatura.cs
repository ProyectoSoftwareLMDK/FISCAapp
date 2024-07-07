using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    public class Asignatura
    {
        [Key]
        public int IdAsignatura { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreAsignatura { get; set; }

        [Required]
        public int IdCarrera { get; set; }

        [Required]
        public int IdGrupo { get; set; }

        [Required]
        public int IdCuatrimestre { get; set; }

    }
}
