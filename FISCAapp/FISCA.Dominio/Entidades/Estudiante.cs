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
        public string car_Estudiante { get; set; }

        [Required]
        [StringLength(50)]
        public string nom_Estudiante { get; set; }

        [Required]
        [StringLength(50)]
        public string ape_Estudiante { get; set; }

        [Required]
        [StringLength(16)]
        public string ced_Estudiante { get; set; }

        [Required]
        [StringLength(50)]
        public string cor_Estududiante { get; set; }

        [Required]
        [StringLength(8)]
        public string cel_Estudiante { get; set; }

        [Required]
        [StringLength(8)]
        public string tel_Estudiante { get; set; }

        [Required]
        [StringLength(250)]
        public string dir_Estudiante { get; set; }

        [Required]
        public int est_Estudiante { get; set; }

        public int? IdGrupo { get; set; }

        [StringLength(100)]
        public string fot_Estudiante { get; set; }

    }
}
