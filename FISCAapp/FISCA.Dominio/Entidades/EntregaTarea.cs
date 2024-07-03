using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    public class EntregaTarea
    {
        [Key]
        public int IdEntregaTareas { get; set; }

        [Required]
        public int CodigoTareaDocente { get; set; }

        [Required]
        public int IdEstudiante { get; set; }

        [Required]
        public int IdAsignatura { get; set; }

        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }

        [Required]
        public int CodigoEnvioTarea { get; set; }

        [Required]
        [StringLength(200)]
        public string Archivo { get; set; }

        public DateTime? FechaEntrega { get; set; }


    }
}
