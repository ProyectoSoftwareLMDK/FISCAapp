using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    public class Mensajes
    {

        [Key] public int IdMensaje { get; set; }
        public string? Remitente { get; set; }
        public string? Correo { get; set; }
        public string? Remitio { get; set; }
        public string? Mensaje { get; set; }
        public DateTime FechaEnvio { get; set; }
    }
}
