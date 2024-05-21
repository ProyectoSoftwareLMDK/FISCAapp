using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Dominio.Entidades
{
    public class Docente
    {
        [Key] public int IdDocente { get; set; }
        public string? NombresDocente { get; set; }
        public string? ApellidosDocente { get; set; }
        public string? CedulaDocente { get; set; }
        public string? CorreoDocente { get; set; }
        public string? CelularDocente { get; set; }
        public string? TelefonoDocente { get; set; }
        public string? DireccionDocente { get; set; }
        public int Estado { get; set; }
        public string? Foto { get; set; }
    }
}
