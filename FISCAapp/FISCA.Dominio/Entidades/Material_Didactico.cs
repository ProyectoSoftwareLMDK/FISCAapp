using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    public class Material_Didactico
    {
        [Key]

        public int IdMaterialDidactico { get; set; }
        public string? Descripcion { get; set; }
        public string? Archivo { get; set;}
        public required int CodigoMaterial { get; set; }
        public DateTime? FechaSubida { get; set; }
        public int IdNumeroAsignacion { get; set; }
        public int IdDocente { get; set; }
    }
}
