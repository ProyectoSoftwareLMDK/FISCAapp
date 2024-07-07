using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    public class Grupo
    {
        [Key]
        public int IdGrupo { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroGrupo { get; set; }

        [Required]
        public string NombreGrupo { get; set; }
    }
}
