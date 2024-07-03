using FISCA.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace FISCA.Infraestructura.Data
{
    public class AplicacionDbContexto : DbContext
    {
        public AplicacionDbContexto(DbContextOptions<AplicacionDbContexto> options) : base(options) { }

        public DbSet<Material_Didactico> MaterialDidacticos { get; set; }
        public DbSet<Inscripciones_Asignaturas> InscripcionesAsignaturas { get; set; }
        public DbSet<Mensajes> Mensajes { get; set; }
        public DbSet<Nivel> Niveles { get; set; }
        public DbSet<Numeros_Asignaciones> NumerosAsignaciones { get; set; }
        public DbSet<YearAcademico> YearAcademicos { get; set; }
        public DbSet<Cuatrimestre> Cuatrimestres { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<EntregaTarea> EntregaTareas { get; set; }
        public DbSet<PlanificacionTarea> PlanificacionTareas { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
        public DbSet<PlanEstudio> PlanEstudios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración adicional de la base de datos si es necesario
        }
    }
}
