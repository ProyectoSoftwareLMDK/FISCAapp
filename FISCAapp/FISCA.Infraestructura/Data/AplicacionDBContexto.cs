using FISCA.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISCA.Infraestructura.Data
{
    public class AplicacionDbContexto : DbContext
    {
        public AplicacionDbContexto(DbContextOptions<AplicacionDbContexto> options) : base(options) { }

        public DbSet<Material_Didactico> materialDidacticos { get; set; }
        public DbSet<Inscripciones_Asignaturas> inscripcionesAsignaturas { get; set; }
        public DbSet<Mensajes> mensajes { get; set; }
        public DbSet<Nivel> niveles { get; set; }
        public DbSet<Numeros_Asignaciones> numeros_Asignaciones { get; set; }
        public DbSet<YearAcademico> yearAcademicos { get; set; }
        public DbSet<Cuatrimestre> cuatrimestres { get; set; }
        public DbSet<Carrera> carreras { get; set; }
        public DbSet<Grupo> grupos { get; set; }
        public DbSet<Horario> horarios { get; set; }
        public DbSet<Turno> turnos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Docente> docentes { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Asignatura> asignaturas { get; set; }
        public DbSet<EntregaTarea> entregaTareas { get; set; }
        public DbSet<PlanificacionTarea> planificacionTareas { get; set; }
        public DbSet<Evaluacion> evaluaciones { get; set; }
        public DbSet<Asignacion> asignaciones { get; set; }
        public DbSet<PlanEstudio> planEstudios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Inscripciones_Asignatura
            modelBuilder.Entity<Inscripciones_Asignaturas>().HasData(

                new Inscripciones_Asignaturas
                {
                    IdInscripcion = 1,
                    IdAsignatura = 1,
                    IdEstudiante = 1,
                    FechaInscripcion = DateTime.ParseExact("01/02/2024", "dd/MM/yyyy", null),
                    Observaciones = "JAJAJAJA"
                },
                    new Inscripciones_Asignaturas
                    {
                        IdInscripcion = 2,
                        IdAsignatura = 2,
                        IdEstudiante = 2,
                        FechaInscripcion = DateTime.ParseExact("01/02/2025", "dd/MM/yyyy", null),
                        Observaciones = "JEJEJEJE"
                    }

            );
            modelBuilder.Entity<Cuatrimestre>().HasData(
            new Cuatrimestre { IdCuatrimestre = 1, NombreCuatrimestre = "Primer Cuatrimestre 2024" },
            new Cuatrimestre { IdCuatrimestre = 2, NombreCuatrimestre = "Segundo Cuatrimestre 2024" }
        );
            modelBuilder.Entity<YearAcademico>().HasData(
            new YearAcademico { IdYearAcademico = 1, NombreYear = "2023-2024" },
            new YearAcademico { IdYearAcademico = 2, NombreYear = "2024-2025" }
        );
            modelBuilder.Entity<Carrera>().HasData(
            new Carrera { IdCarrera = 1, NombreCarrera = "Ingeniería Informática" },
            new Carrera { IdCarrera = 2, NombreCarrera = "Ingeniería Civil" }
        );
            modelBuilder.Entity<Grupo>().HasData(
            new Grupo { IdGrupo = 1, NumeroGrupo = "G1", NombreGrupo = "Grupo 1" },
            new Grupo { IdGrupo = 2, NumeroGrupo = "G2", NombreGrupo = "Grupo 2" }
        );
            modelBuilder.Entity<Horario>().HasData(
            new Horario { IdHorario = 1, NombreHorario = "Horario Matutino" },
            new Horario { IdHorario = 2, NombreHorario = "Horario Vespertino" }
        );
            modelBuilder.Entity<Turno>().HasData(
            new Turno { IdTurno = 1, NombreTurno = "Turno de Mañana" },
            new Turno { IdTurno = 2, NombreTurno = "Turno de Tarde" }
        );
            modelBuilder.Entity<Estudiante>().HasData(
            new Estudiante
            {
                IdEstudiante = 1,
                CarnetEstudiante = "C123456",
                NombresEstudiante = "Juan",
                ApellidosEstudiante = "Pérez",
                CedulaEstudiante = "1234567890123456",
                CorreoEstudiante = "juan.perez@example.com",
                CelularEstudiante = "12345678",
                TelefonoEstudiante = "87654321",
                DireccionEstudiante = "Calle Falsa 123",
                Estado = 1,
                IdGrupo = 1,
                Foto = "juan.jpg"
            },
            new Estudiante
            {
                IdEstudiante = 2,
                CarnetEstudiante = "C654321",
                NombresEstudiante = "Ana",
                ApellidosEstudiante = "García",
                CedulaEstudiante = "6543210987654321",
                CorreoEstudiante = "ana.garcia@example.com",
                CelularEstudiante = "87654321",
                TelefonoEstudiante = "12345678",
                DireccionEstudiante = "Avenida Siempre Viva 742",
                Estado = 1,
                IdGrupo = 2,
                Foto = "ana.jpg"
            }
        );
            modelBuilder.Entity<Docente>().HasData(
    new Docente
    {
        IdDocente = 1,
        NombresDocente = "Juan",
        ApellidosDocente = "Pérez",
        CedulaDocente = "1234567890123456",
        CorreoDocente = "juan.perez@example.com",
        CelularDocente = "87654321",
        TelefonoDocente = "12345678",
        DireccionDocente = "Calle Falsa 123",
        Estado = 1,
        Foto = "juan.jpg"
    },
    new Docente
    {
        IdDocente = 2,
        NombresDocente = "Ana",
        ApellidosDocente = "García",
        CedulaDocente = "6543210987654321",
        CorreoDocente = "ana.garcia@example.com",
        CelularDocente = "87654321",
        TelefonoDocente = "12345678",
        DireccionDocente = "Avenida Siempre Viva 742",
        Estado = 1,
        Foto = "ana.jpg"
    }
);
            modelBuilder.Entity<Material_Didactico>().HasData(
                new Material_Didactico
                {
                    IdMaterialDidactico = 1,
                    Descripcion = "Hotel 01",
                    Archivo = "Hotel 1 star",
                    CodigoMaterial = 1,
                    FechaSubida = DateTime.ParseExact("01/02/2023", "dd/MM/yyyy", null),
                    IdNumeroAsignacion = 1,
                    IdDocente = 1
                },
                new Material_Didactico
                {
                    IdMaterialDidactico = 2,
                    Descripcion = "Hotel 02",
                    Archivo = "Hotel 2 star",
                    CodigoMaterial = 2,
                    FechaSubida = DateTime.ParseExact("01/02/2023", "dd/MM/yyyy", null),
                    IdNumeroAsignacion = 2,
                    IdDocente = 2
                }
            );
            modelBuilder.Entity<Mensajes>().HasData(
                new Mensajes
                {
                    IdMensaje = 1,
                    Remitente = "Juan",
                    Correo = "diego@gmail.com",
                    Remitio = "Pedro",
                    Mensaje = "Anuel AA",
                    FechaEnvio = DateTime.ParseExact("01/02/2026", "dd/MM/yyyy", null),

                },
                 new Mensajes
                 {
                     IdMensaje = 2,
                     Remitente = "Juana",
                     Correo = "die@gmail.com",
                     Remitio = "Pedra",
                     Mensaje = "Anuela AA",
                     FechaEnvio = DateTime.ParseExact("01/02/2027", "dd/MM/yyyy", null),
                 }
                );
            modelBuilder.Entity<Nivel>().HasData(
                new Nivel
                {
                    IdNivel = 1,
                    NombreNivel = "pollo",
                },
                 new Nivel
                 {
                     IdNivel = 2,
                     NombreNivel = "Gumball",
                 }
                );
            modelBuilder.Entity<Numeros_Asignaciones>().HasData(
                new Numeros_Asignaciones
                {
                    IdNumerosAsignaciones = 1,
                    NumeroAsignado = 1,
                    IdDocente = 1,
                }
                );
            modelBuilder.Entity<Usuario>().HasData(
    new Usuario
    {
        IdUsuario = 1,
        NombreUsuario = "usuario1",
        PassUsuario = "contraseña1",
        NivelUsuario = 1,
        Codigo = 12345,
        Foto = "usuario1.jpg"
    },
    new Usuario
    {
        IdUsuario = 2,
        NombreUsuario = "usuario2",
        PassUsuario = "contraseña2",
        NivelUsuario = 2,
        Codigo = 54321,
        Foto = "usuario2.jpg"
    }
);
            modelBuilder.Entity<Asignatura>().HasData(
    new Asignatura
    {
        IdAsignatura = 1,
        NombreAsignatura = "Matemáticas",
        IdCarrera = 1,
        IdGrupo = 1,
        IdCuatrimestre = 1
    },
    new Asignatura
    {
        IdAsignatura = 2,
        NombreAsignatura = "Física",
        IdCarrera = 1,
        IdGrupo = 2,
        IdCuatrimestre = 2
    }
);
            modelBuilder.Entity<EntregaTarea>().HasData(
    new EntregaTarea
    {
        IdEntregaTareas = 1,
        CodigoTareaDocente = 123,
        IdEstudiante = 1,
        IdAsignatura = 1,
        Descripcion = "Entrega de tarea 1",
        CodigoEnvioTarea = 456,
        Archivo = "tarea1.pdf",
        FechaEntrega = new DateTime(2024, 5, 25)
    },
    new EntregaTarea
    {
        IdEntregaTareas = 2,
        CodigoTareaDocente = 456,
        IdEstudiante = 2,
        IdAsignatura = 2,
        Descripcion = "Entrega de tarea 2",
        CodigoEnvioTarea = 789,
        Archivo = "tarea2.docx",
        FechaEntrega = new DateTime(2024, 5, 28)
    }
);
            modelBuilder.Entity<PlanificacionTarea>().HasData(
    new PlanificacionTarea
    {
        IdPlanificacion = 1,
        IdDocente = 1,
        IdNumeroAsignacion = 1,
        IdAsignatura = 1,
        Unidad = "Unidad 1",
        DescripcionUnidad = "Descripción de la Unidad 1",
        Tarea = "Tarea 1",
        DescripcionTarea = "Descripción de la Tarea 1",
        FechaPublicacion = new DateTime(2024, 5, 1),
        FechaPresentacion = new DateTime(2024, 5, 15),
        CodigoTarea = 12345
    },
    new PlanificacionTarea
    {
        IdPlanificacion = 2,
        IdDocente = 2,
        IdNumeroAsignacion = 2,
        IdAsignatura = 2,
        Unidad = "Unidad 2",
        DescripcionUnidad = "Descripción de la Unidad 2",
        Tarea = "Tarea 2",
        DescripcionTarea = "Descripción de la Tarea 2",
        FechaPublicacion = new DateTime(2024, 5, 10),
        FechaPresentacion = new DateTime(2024, 5, 25),
        CodigoTarea = 54321
    }
);
            modelBuilder.Entity<Evaluacion>().HasData(
    new Evaluacion
    {
        IdEvaluacion = 1,
        Descripcion = "Prueba parcial",
        IdEstudiante = 1,
        IdAsignatura = 1,
        Unidad = "Unidad 1",
        Tarea = "Tarea 1",
        IdDocente = 1,
        Puntaje = 90,
        FechaEvaluacion = new DateTime(2024, 5, 10)
    },
    new Evaluacion
    {
        IdEvaluacion = 2,
        Descripcion = "Examen final",
        IdEstudiante = 2,
        IdAsignatura = 2,
        Unidad = "Unidad 2",
        Tarea = "Tarea 2",
        IdDocente = 2,
        Puntaje = 85,
        FechaEvaluacion = new DateTime(2024, 5, 20)
    }
);
            modelBuilder.Entity<Asignacion>().HasData(
    new Asignacion
    {
        IdAsignacion = 1,
        Descripcion = "Asignación 1",
        IdDocente = 1,
        IdAsignatura = 1,
        IdGrupo = 1,
        IdTurno = 1,
        IdHorario = 1,
        Estado = "Activo",
        NumeroAsignacion = 1
    },
    new Asignacion
    {
        IdAsignacion = 2,
        Descripcion = "Asignación 2",
        IdDocente = 2,
        IdAsignatura = 2,
        IdGrupo = 2,
        IdTurno = 2,
        IdHorario = 2,
        Estado = "Inactivo",
        NumeroAsignacion = 2
    }
);
            modelBuilder.Entity<PlanEstudio>().HasData(
    new PlanEstudio
    {
        IdPlan = 1,
        Descripcion = "Plan de Estudio 1",
        IdCarrera = 1,
        CantidadAsignaturas = 10
    },
    new PlanEstudio
    {
        IdPlan = 2,
        Descripcion = "Plan de Estudio 2",
        IdCarrera = 2,
        CantidadAsignaturas = 12
    }
);



        }
    }
}

