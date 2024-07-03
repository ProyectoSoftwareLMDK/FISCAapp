﻿// <auto-generated />
using System;
using FISCA.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FISCA.Infraestructura.Migrations
{
    [DbContext(typeof(AplicacionDbContexto))]
    [Migration("20240522185229_p01")]
    partial class p01
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FISCA.Dominio.Entidades.Asignacion", b =>
                {
                    b.Property<int>("IdAsignacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAsignacion"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("IdAsignatura")
                        .HasColumnType("int");

                    b.Property<int>("IdDocente")
                        .HasColumnType("int");

                    b.Property<int>("IdGrupo")
                        .HasColumnType("int");

                    b.Property<int>("IdHorario")
                        .HasColumnType("int");

                    b.Property<int>("IdTurno")
                        .HasColumnType("int");

                    b.Property<int>("NumeroAsignacion")
                        .HasColumnType("int");

                    b.HasKey("IdAsignacion");

                    b.ToTable("asignaciones");

                    b.HasData(
                        new
                        {
                            IdAsignacion = 1,
                            Descripcion = "Asignación 1",
                            Estado = "Activo",
                            IdAsignatura = 1,
                            IdDocente = 1,
                            IdGrupo = 1,
                            IdHorario = 1,
                            IdTurno = 1,
                            NumeroAsignacion = 1
                        },
                        new
                        {
                            IdAsignacion = 2,
                            Descripcion = "Asignación 2",
                            Estado = "Inactivo",
                            IdAsignatura = 2,
                            IdDocente = 2,
                            IdGrupo = 2,
                            IdHorario = 2,
                            IdTurno = 2,
                            NumeroAsignacion = 2
                        });
                });

            modelBuilder.Entity("FISCA.Dominio.Entidades.Asignatura", b =>
                {
                    b.Property<int>("IdAsignatura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAsignatura"));

                    b.Property<int>("IdCarrera")
                        .HasColumnType("int");

                    b.Property<int>("IdCuatrimestre")
                        .HasColumnType("int");

                    b.Property<int>("IdGrupo")
                        .HasColumnType("int");

                    b.Property<string>("NombreAsignatura")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdAsignatura");

                    b.ToTable("asignaturas");

                    b.HasData(
                        new
                        {
                            IdAsignatura = 1,
                            IdCarrera = 1,
                            IdCuatrimestre = 1,
                            IdGrupo = 1,
                            NombreAsignatura = "Matemáticas"
                        },
                        new
                        {
                            IdAsignatura = 2,
                            IdCarrera = 1,
                            IdCuatrimestre = 2,
                            IdGrupo = 2,
                            NombreAsignatura = "Física"
                        });
                });

            modelBuilder.Entity("FISCA.Dominio.Entidades.Carrera", b =>
                {
                    b.Property<int>("IdCarrera")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCarrera"));

                    b.Property<string>("NombreCarrera")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCarrera");

                    b.ToTable("carreras");

                    b.HasData(
                        new
                        {
                            IdCarrera = 1,
                            NombreCarrera = "Ingeniería Informática"
                        },
                        new
                        {
                            IdCarrera = 2,
                            NombreCarrera = "Ingeniería Civil"
                        });
                });

            modelBuilder.Entity("FISCA.Dominio.Entidades.Cuatrimestre", b =>
                {
                    b.Property<int>("IdCuatrimestre")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCuatrimestre"));

                    b.Property<string>("NombreCuatrimestre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCuatrimestre");

                    b.ToTable("cuatrimestres");

                    b.HasData(
                        new
                        {
                            IdCuatrimestre = 1,
                            NombreCuatrimestre = "Primer Cuatrimestre 2024"
                        },
                        new
                        {
                            IdCuatrimestre = 2,
                            NombreCuatrimestre = "Segundo Cuatrimestre 2024"
                        });
                });

            modelBuilder.Entity("FISCA.Dominio.Entidades.Docente", b =>
                {
                    b.Property<int>("IdDocente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDocente"));

                    b.Property<string>("ApellidosDocente")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CedulaDocente")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("CelularDocente")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("CorreoDocente")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DireccionDocente")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NombresDocente")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TelefonoDocente")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("IdDocente");

                    b.ToTable("docentes");

                    b.HasData(
                        new
                        {
                            IdDocente = 1,
                            ApellidosDocente = "Pérez",
                            CedulaDocente = "1234567890123456",
                            CelularDocente = "87654321",
                            CorreoDocente = "juan.perez@example.com",
                            DireccionDocente = "Calle Falsa 123",
                            Estado = 1,
                            Foto = "juan.jpg",
                            NombresDocente = "Juan",
                            TelefonoDocente = "12345678"
                        },
                        new
                        {
                            IdDocente = 2,
                            ApellidosDocente = "García",
                            CedulaDocente = "6543210987654321",
                            CelularDocente = "87654321",
                            CorreoDocente = "ana.garcia@example.com",
                            DireccionDocente = "Avenida Siempre Viva 742",
                            Estado = 1,
                            Foto = "ana.jpg",
                            NombresDocente = "Ana",
                            TelefonoDocente = "12345678"
                        });
                });

            modelBuilder.Entity("FISCA.Dominio.Entidades.EntregaTarea", b =>
                {
                    b.Property<int>("IdEntregaTareas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEntregaTareas"));

                    b.Property<string>("Archivo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("CodigoEnvioTarea")
                        .HasColumnType("int");

                    b.Property<int>("CodigoTareaDocente")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAsignatura")
                        .HasColumnType("int");

                    b.Property<int>("IdEstudiante")
                        .HasColumnType("int");

                    b.HasKey("IdEntregaTareas");

                    b.ToTable("entregaTareas");

                    b.HasData(
                        new
                        {
                            IdEntregaTareas = 1,
                            Archivo = "tarea1.pdf",
                            CodigoEnvioTarea = 456,
                            CodigoTareaDocente = 123,
                            Descripcion = "Entrega de tarea 1",
                            FechaEntrega = new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdAsignatura = 1,
                            IdEstudiante = 1
                        },
                        new
                        {
                            IdEntregaTareas = 2,
                            Archivo = "tarea2.docx",
                            CodigoEnvioTarea = 789,
                            CodigoTareaDocente = 456,
                            Descripcion = "Entrega de tarea 2",
                            FechaEntrega = new DateTime(2024, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdAsignatura = 2,
                            IdEstudiante = 2
                        });
                });

            modelBuilder.Entity("FISCA.Dominio.Entidades.Estudiante", b =>
                {
                    b.Property<int>("IdEstudiante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstudiante"));

                    b.Property<string>("ApellidosEstudiante")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CarnetEstudiante")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CedulaEstudiante")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("CelularEstudiante")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("CorreoEstudiante")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DireccionEstudiante")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("IdGrupo")
                        .HasColumnType("int");

                    b.Property<string>("NombresEstudiante")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TelefonoEstudiante")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("IdEstudiante");

                    b.ToTable("Estudiantes");

                    b.HasData(
                        new
                        {
                            IdEstudiante = 1,
                            ApellidosEstudiante = "Pérez",
                            CarnetEstudiante = "C123456",
                            CedulaEstudiante = "1234567890123456",
                            CelularEstudiante = "12345678",
                            CorreoEstudiante = "juan.perez@example.com",
                            DireccionEstudiante = "Calle Falsa 123",
                            Estado = 1,
                            Foto = "juan.jpg",
                            IdGrupo = 1,
                            NombresEstudiante = "Juan",
                            TelefonoEstudiante = "87654321"
                        },
                        new
                        {
                            IdEstudiante = 2,
                            ApellidosEstudiante = "García",
                            CarnetEstudiante = "C654321",
                            CedulaEstudiante = "6543210987654321",
                            CelularEstudiante = "87654321",
                            CorreoEstudiante = "ana.garcia@example.com",
                            DireccionEstudiante = "Avenida Siempre Viva 742",
                            Estado = 1,
                            Foto = "ana.jpg",
                            IdGrupo = 2,
                            NombresEstudiante = "Ana",
                            TelefonoEstudiante = "12345678"
                        });
                });

            modelBuilder.Entity("FISCA.Dominio.Entidades.Evaluacion", b =>
                {
                    b.Property<int>("IdEvaluacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEvaluacion"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("FechaEvaluacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAsignatura")
                        .HasColumnType("int");

                    b.Property<int>("IdDocente")
                        .HasColumnType("int");

                    b.Property<int>("IdEstudiante")
                        .HasColumnType("int");

                    b.Property<int>("Puntaje")
                        .HasColumnType("int");

                    b.Property<string>("Tarea")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Unidad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdEvaluacion");

                    b.ToTable("evaluaciones");

                    b.HasData(
                        new
                        {
                            IdEvaluacion = 1,
                            Descripcion = "Prueba parcial",
                            FechaEvaluacion = new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdAsignatura = 1,
                            IdDocente = 1,
                            IdEstudiante = 1,
                            Puntaje = 90,
                            Tarea = "Tarea 1",
                            Unidad = "Unidad 1"
                        },
                        new
                        {
                            IdEvaluacion = 2,
                            Descripcion = "Examen final",
                            FechaEvaluacion = new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdAsignatura = 2,
                            IdDocente = 2,
                            IdEstudiante = 2,
                            Puntaje = 85,
                            Tarea = "Tarea 2",
                            Unidad = "Unidad 2"
                        });
                });

            modelBuilder.Entity("FISCA.Dominio.Entidades.Grupo", b =>
                {
                    b.Property<int>("IdGrupo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGrupo"));

                    b.Property<string>("NombreGrupo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroGrupo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdGrupo");

                    b.ToTable("grupos");

                    b.HasData(
                        new
                        {
                            IdGrupo = 1,
                            NombreGrupo = "Grupo 1",
                            NumeroGrupo = "G1"
                        },
                        new
                        {
                            IdGrupo = 2,
                            NombreGrupo = "Grupo 2",
                            NumeroGrupo = "G2"
                        });
                });

            modelBuilder.Entity("FISCA.Dominio.Entidades.Horario", b =>
                {
                    b.Property<int>("IdHorario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHorario"));

                    b.Property<string>("NombreHorario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdHorario");

                    b.ToTable("horarios");

                    b.HasData(
                        new
                        {
                            IdHorario = 1,
                            NombreHorario = "Horario Matutino"
                        },
                        new
                        {
                            IdHorario = 2,
                            NombreHorario = "Horario Vespertino"
                        });
                });

            modelBuilder.Entity("FISCA.Dominio.Entidades.Inscripciones_Asignaturas", b =>
                {
                    b.Property<int>("IdInscripcion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInscripcion"));

                    b.Property<DateTime?>("FechaInscripcion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAsignatura")
                        .HasColumnType("int");

                    b.Property<int>("IdEstudiante")
                        .HasColumnType("int");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdInscripcion");

                    b.ToTable("inscripcionesAsignaturas");

                    b.HasData(
                        new
                        {
                            IdInscripcion = 1,
                            FechaInscripcion = new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdAsignatura = 1,
                            IdEstudiante = 1,
                            Observaciones = "JAJAJAJA"
                        },
                        new
                        {
                            IdInscripcion = 2,
                            FechaInscripcion = new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdAsignatura = 2,
                            IdEstudiante = 2,
                            Observaciones = "JEJEJEJE"
                        });
                });

            modelBuilder.Entity("FISCA.Dominio.Entidades.Material_Didactico", b =>
                {
                    b.Property<int>("IdMaterialDidactico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMaterialDidactico"));

                    b.Property<string>("Archivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CodigoMaterial")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaSubida")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDocente")
                        .HasColumnType("int");

                    b.Property<int>("IdNumeroAsignacion")
                        .HasColumnType("int");

                    b.HasKey("IdMaterialDidactico");

                    b.ToTable("materialDidacticos");

                    b.HasData(
                        new
                        {
                            IdMaterialDidactico = 1,
                            Archivo = "Hotel 1 star",
                            CodigoMaterial = 1,
                            Descripcion = "Hotel 01",
                            FechaSubida = new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDocente = 1,
                            IdNumeroAsignacion = 1
                        },
                        new
                        {
                            IdMaterialDidactico = 2,
                            Archivo = "Hotel 2 star",
                            CodigoMaterial = 2,
                            Descripcion = "Hotel 02",
                            FechaSubida = new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDocente = 2,
                            IdNumeroAsignacion = 2
                        });
                });

            modelBuilder.Entity("FISCA.Dominio.Entidades.Mensajes", b =>
                {
                    b.Property<int>("IdMensaje")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMensaje"));

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaEnvio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mensaje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remitente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remitio")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMensaje");

                    b.ToTable("mensajes");

                    b.HasData(
                        new
                        {
                            IdMensaje = 1,
                            Correo = "diego@gmail.com",
                            FechaEnvio = new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Mensaje = "Anuel AA",
                            Remitente = "Juan",
                            Remitio = "Pedro"
                        },
                        new
                        {
                            IdMensaje = 2,
                            Correo = "die@gmail.com",
                            FechaEnvio = new DateTime(2027, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Mensaje = "Anuela AA",
                            Remitente = "Juana",
                            Remitio = "Pedra"
                        });
                });

            modelBuilder.Entity("FISCA.Dominio.Entidades.Nivel", b =>
                {
                    b.Property<int>("IdNivel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdNivel"));

                    b.Property<string>("NombreNivel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdNivel");

                    b.ToTable("niveles");

                    b.HasData(
                        new
                        {
                            IdNivel = 1,
                            NombreNivel = "pollo"
                        },
                        new
                        {
                            IdNivel = 2,
                            NombreNivel = "Gumball"
                        });
                });

            modelBuilder.Entity("FISCA.Dominio.Entidades.Numeros_Asignaciones", b =>
                {
                    b.Property<int>("IdNumerosAsignaciones")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdNumerosAsignaciones"));

                    b.Property<int>("IdDocente")
                        .HasColumnType("int");

                    b.Property<int>("NumeroAsignado")
                        .HasColumnType("int");

                    b.HasKey("IdNumerosAsignaciones");

                    b.ToTable("numeros_Asignaciones");

                    b.HasData(
                        new
                        {
                            IdNumerosAsignaciones = 1,
                            IdDocente = 1,
                            NumeroAsignado = 1
                        });
                });

            modelBuilder.Entity("FISCA.Dominio.Entidades.PlanEstudio", b =>
                {
                    b.Property<int>("IdPlan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPlan"));

                    b.Property<int>("CantidadAsignaturas")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdCarrera")
                        .HasColumnType("int");

                    b.HasKey("IdPlan");

                    b.ToTable("planEstudios");

                    b.HasData(
                        new
                        {
                            IdPlan = 1,
                            CantidadAsignaturas = 10,
                            Descripcion = "Plan de Estudio 1",
                            IdCarrera = 1
                        },
                        new
                        {
                            IdPlan = 2,
                            CantidadAsignaturas = 12,
                            Descripcion = "Plan de Estudio 2",
                            IdCarrera = 2
                        });
                });

            modelBuilder.Entity("FISCA.Dominio.Entidades.PlanificacionTarea", b =>
                {
                    b.Property<int>("IdPlanificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPlanificacion"));

                    b.Property<int>("CodigoTarea")
                        .HasColumnType("int");

                    b.Property<string>("DescripcionTarea")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DescripcionUnidad")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("FechaPresentacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaPublicacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAsignatura")
                        .HasColumnType("int");

                    b.Property<int>("IdDocente")
                        .HasColumnType("int");

                    b.Property<int>("IdNumeroAsignacion")
                        .HasColumnType("int");

                    b.Property<string>("Tarea")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Unidad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdPlanificacion");

                    b.ToTable("planificacionTareas");

                    b.HasData(
                        new
                        {
                            IdPlanificacion = 1,
                            CodigoTarea = 12345,
                            DescripcionTarea = "Descripción de la Tarea 1",
                            DescripcionUnidad = "Descripción de la Unidad 1",
                            FechaPresentacion = new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaPublicacion = new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdAsignatura = 1,
                            IdDocente = 1,
                            IdNumeroAsignacion = 1,
                            Tarea = "Tarea 1",
                            Unidad = "Unidad 1"
                        },
                        new
                        {
                            IdPlanificacion = 2,
                            CodigoTarea = 54321,
                            DescripcionTarea = "Descripción de la Tarea 2",
                            DescripcionUnidad = "Descripción de la Unidad 2",
                            FechaPresentacion = new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaPublicacion = new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdAsignatura = 2,
                            IdDocente = 2,
                            IdNumeroAsignacion = 2,
                            Tarea = "Tarea 2",
                            Unidad = "Unidad 2"
                        });
                });

            modelBuilder.Entity("FISCA.Dominio.Entidades.Turno", b =>
                {
                    b.Property<int>("IdTurno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTurno"));

                    b.Property<string>("NombreTurno")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdTurno");

                    b.ToTable("turnos");

                    b.HasData(
                        new
                        {
                            IdTurno = 1,
                            NombreTurno = "Turno de Mañana"
                        },
                        new
                        {
                            IdTurno = 2,
                            NombreTurno = "Turno de Tarde"
                        });
                });

            modelBuilder.Entity("FISCA.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<short>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("IdUsuario"));

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NivelUsuario")
                        .HasColumnType("int");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PassUsuario")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("IdUsuario");

                    b.ToTable("usuarios");

                    b.HasData(
                        new
                        {
                            IdUsuario = (short)1,
                            Codigo = 12345,
                            Foto = "usuario1.jpg",
                            NivelUsuario = 1,
                            NombreUsuario = "usuario1",
                            PassUsuario = "contraseña1"
                        },
                        new
                        {
                            IdUsuario = (short)2,
                            Codigo = 54321,
                            Foto = "usuario2.jpg",
                            NivelUsuario = 2,
                            NombreUsuario = "usuario2",
                            PassUsuario = "contraseña2"
                        });
                });

            modelBuilder.Entity("FISCA.Dominio.Entidades.YearAcademico", b =>
                {
                    b.Property<int>("IdYearAcademico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdYearAcademico"));

                    b.Property<string>("NombreYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdYearAcademico");

                    b.ToTable("yearAcademicos");

                    b.HasData(
                        new
                        {
                            IdYearAcademico = 1,
                            NombreYear = "2023-2024"
                        },
                        new
                        {
                            IdYearAcademico = 2,
                            NombreYear = "2024-2025"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}