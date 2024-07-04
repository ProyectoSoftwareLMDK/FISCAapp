using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FISCA.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class _03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "asignaciones",
                columns: table => new
                {
                    IdAsignacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdDocente = table.Column<int>(type: "int", nullable: false),
                    IdAsignatura = table.Column<int>(type: "int", nullable: false),
                    IdGrupo = table.Column<int>(type: "int", nullable: false),
                    IdTurno = table.Column<int>(type: "int", nullable: false),
                    IdHorario = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    NumeroAsignacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asignaciones", x => x.IdAsignacion);
                });

            migrationBuilder.CreateTable(
                name: "asignaturas",
                columns: table => new
                {
                    IdAsignatura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAsignatura = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdCarrera = table.Column<int>(type: "int", nullable: false),
                    IdGrupo = table.Column<int>(type: "int", nullable: false),
                    IdCuatrimestre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asignaturas", x => x.IdAsignatura);
                });

            migrationBuilder.CreateTable(
                name: "carreras",
                columns: table => new
                {
                    IdCarrera = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCarrera = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carreras", x => x.IdCarrera);
                });

            migrationBuilder.CreateTable(
                name: "cuatrimestres",
                columns: table => new
                {
                    IdCuatrimestre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCuatrimestre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuatrimestres", x => x.IdCuatrimestre);
                });

            migrationBuilder.CreateTable(
                name: "docentes",
                columns: table => new
                {
                    IdDocente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombresDocente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApellidosDocente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CedulaDocente = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    CorreoDocente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CelularDocente = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    TelefonoDocente = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    DireccionDocente = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_docentes", x => x.IdDocente);
                });

            migrationBuilder.CreateTable(
                name: "entregaTareas",
                columns: table => new
                {
                    IdEntregaTareas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoTareaDocente = table.Column<int>(type: "int", nullable: false),
                    IdEstudiante = table.Column<int>(type: "int", nullable: false),
                    IdAsignatura = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CodigoEnvioTarea = table.Column<int>(type: "int", nullable: false),
                    Archivo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entregaTareas", x => x.IdEntregaTareas);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    IdEstudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    car_Estudiante = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nom_Estudiante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ape_Estudiante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ced_Estudiante = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    cor_Estududiante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cel_Estudiante = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    tel_Estudiante = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    dir_Estudiante = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    est_Estudiante = table.Column<int>(type: "int", nullable: false),
                    IdGrupo = table.Column<int>(type: "int", nullable: true),
                    fot_Estudiante = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.IdEstudiante);
                });

            migrationBuilder.CreateTable(
                name: "evaluaciones",
                columns: table => new
                {
                    IdEvaluacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdEstudiante = table.Column<int>(type: "int", nullable: false),
                    IdAsignatura = table.Column<int>(type: "int", nullable: false),
                    Unidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tarea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdDocente = table.Column<int>(type: "int", nullable: false),
                    Puntaje = table.Column<int>(type: "int", nullable: false),
                    FechaEvaluacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evaluaciones", x => x.IdEvaluacion);
                });

            migrationBuilder.CreateTable(
                name: "grupos",
                columns: table => new
                {
                    IdGrupo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroGrupo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NombreGrupo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupos", x => x.IdGrupo);
                });

            migrationBuilder.CreateTable(
                name: "horarios",
                columns: table => new
                {
                    IdHorario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreHorario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_horarios", x => x.IdHorario);
                });

            migrationBuilder.CreateTable(
                name: "inscripcionesAsignaturas",
                columns: table => new
                {
                    IdInscripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAsignatura = table.Column<int>(type: "int", nullable: false),
                    IdEstudiante = table.Column<int>(type: "int", nullable: false),
                    FechaInscripcion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inscripcionesAsignaturas", x => x.IdInscripcion);
                });

            migrationBuilder.CreateTable(
                name: "materialDidacticos",
                columns: table => new
                {
                    IdMaterialDidactico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoMaterial = table.Column<int>(type: "int", nullable: false),
                    FechaSubida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdNumeroAsignacion = table.Column<int>(type: "int", nullable: false),
                    IdDocente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materialDidacticos", x => x.IdMaterialDidactico);
                });

            migrationBuilder.CreateTable(
                name: "mensajes",
                columns: table => new
                {
                    IdMensaje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Remitente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remitio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEnvio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mensajes", x => x.IdMensaje);
                });

            migrationBuilder.CreateTable(
                name: "niveles",
                columns: table => new
                {
                    IdNivel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreNivel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_niveles", x => x.IdNivel);
                });

            migrationBuilder.CreateTable(
                name: "numeros_Asignaciones",
                columns: table => new
                {
                    IdNumerosAsignaciones = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroAsignado = table.Column<int>(type: "int", nullable: false),
                    IdDocente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_numeros_Asignaciones", x => x.IdNumerosAsignaciones);
                });

            migrationBuilder.CreateTable(
                name: "planEstudios",
                columns: table => new
                {
                    IdPlan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdCarrera = table.Column<int>(type: "int", nullable: false),
                    CantidadAsignaturas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planEstudios", x => x.IdPlan);
                });

            migrationBuilder.CreateTable(
                name: "planificacionTareas",
                columns: table => new
                {
                    IdPlanificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDocente = table.Column<int>(type: "int", nullable: false),
                    IdNumeroAsignacion = table.Column<int>(type: "int", nullable: false),
                    IdAsignatura = table.Column<int>(type: "int", nullable: false),
                    Unidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescripcionUnidad = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tarea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescripcionTarea = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaPresentacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodigoTarea = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planificacionTareas", x => x.IdPlanificacion);
                });

            migrationBuilder.CreateTable(
                name: "turnos",
                columns: table => new
                {
                    IdTurno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTurno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turnos", x => x.IdTurno);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PassUsuario = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NivelUsuario = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "yearAcademicos",
                columns: table => new
                {
                    IdYearAcademico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreYear = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yearAcademicos", x => x.IdYearAcademico);
                });

            migrationBuilder.InsertData(
                table: "Estudiantes",
                columns: new[] { "IdEstudiante", "IdGrupo", "ape_Estudiante", "car_Estudiante", "ced_Estudiante", "cel_Estudiante", "cor_Estududiante", "dir_Estudiante", "est_Estudiante", "fot_Estudiante", "nom_Estudiante", "tel_Estudiante" },
                values: new object[,]
                {
                    { 1, 1, "Pérez", "C123456", "1234567890123456", "12345678", "juan.perez@example.com", "Calle Falsa 123", 1, "juan.jpg", "Juan", "87654321" },
                    { 2, 2, "García", "C654321", "6543210987654321", "87654321", "ana.garcia@example.com", "Avenida Siempre Viva 742", 1, "ana.jpg", "Ana", "12345678" }
                });

            migrationBuilder.InsertData(
                table: "asignaciones",
                columns: new[] { "IdAsignacion", "Descripcion", "Estado", "IdAsignatura", "IdDocente", "IdGrupo", "IdHorario", "IdTurno", "NumeroAsignacion" },
                values: new object[,]
                {
                    { 1, "Asignación 1", "Activo", 1, 1, 1, 1, 1, 1 },
                    { 2, "Asignación 2", "Inactivo", 2, 2, 2, 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "asignaturas",
                columns: new[] { "IdAsignatura", "IdCarrera", "IdCuatrimestre", "IdGrupo", "NombreAsignatura" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, "Matemáticas" },
                    { 2, 1, 2, 2, "Física" }
                });

            migrationBuilder.InsertData(
                table: "carreras",
                columns: new[] { "IdCarrera", "NombreCarrera" },
                values: new object[,]
                {
                    { 1, "Ingeniería Informática" },
                    { 2, "Ingeniería Civil" }
                });

            migrationBuilder.InsertData(
                table: "cuatrimestres",
                columns: new[] { "IdCuatrimestre", "NombreCuatrimestre" },
                values: new object[,]
                {
                    { 1, "Primer Cuatrimestre 2024" },
                    { 2, "Segundo Cuatrimestre 2024" }
                });

            migrationBuilder.InsertData(
                table: "docentes",
                columns: new[] { "IdDocente", "ApellidosDocente", "CedulaDocente", "CelularDocente", "CorreoDocente", "DireccionDocente", "Estado", "Foto", "NombresDocente", "TelefonoDocente" },
                values: new object[,]
                {
                    { 1, "Pérez", "1234567890123456", "87654321", "juan.perez@example.com", "Calle Falsa 123", 1, "juan.jpg", "Juan", "12345678" },
                    { 2, "García", "6543210987654321", "87654321", "ana.garcia@example.com", "Avenida Siempre Viva 742", 1, "ana.jpg", "Ana", "12345678" }
                });

            migrationBuilder.InsertData(
                table: "entregaTareas",
                columns: new[] { "IdEntregaTareas", "Archivo", "CodigoEnvioTarea", "CodigoTareaDocente", "Descripcion", "FechaEntrega", "IdAsignatura", "IdEstudiante" },
                values: new object[,]
                {
                    { 1, "tarea1.pdf", 456, 123, "Entrega de tarea 1", new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, "tarea2.docx", 789, 456, "Entrega de tarea 2", new DateTime(2024, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "evaluaciones",
                columns: new[] { "IdEvaluacion", "Descripcion", "FechaEvaluacion", "IdAsignatura", "IdDocente", "IdEstudiante", "Puntaje", "Tarea", "Unidad" },
                values: new object[,]
                {
                    { 1, "Prueba parcial", new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, 90, "Tarea 1", "Unidad 1" },
                    { 2, "Examen final", new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 2, 85, "Tarea 2", "Unidad 2" }
                });

            migrationBuilder.InsertData(
                table: "grupos",
                columns: new[] { "IdGrupo", "NombreGrupo", "NumeroGrupo" },
                values: new object[,]
                {
                    { 1, "Grupo 1", "G1" },
                    { 2, "Grupo 2", "G2" }
                });

            migrationBuilder.InsertData(
                table: "horarios",
                columns: new[] { "IdHorario", "NombreHorario" },
                values: new object[,]
                {
                    { 1, "Horario Matutino" },
                    { 2, "Horario Vespertino" }
                });

            migrationBuilder.InsertData(
                table: "inscripcionesAsignaturas",
                columns: new[] { "IdInscripcion", "FechaInscripcion", "IdAsignatura", "IdEstudiante", "Observaciones" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "JAJAJAJA" },
                    { 2, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "JEJEJEJE" }
                });

            migrationBuilder.InsertData(
                table: "materialDidacticos",
                columns: new[] { "IdMaterialDidactico", "Archivo", "CodigoMaterial", "Descripcion", "FechaSubida", "IdDocente", "IdNumeroAsignacion" },
                values: new object[,]
                {
                    { 1, "Hotel 1 star", 1, "Hotel 01", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, "Hotel 2 star", 2, "Hotel 02", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "mensajes",
                columns: new[] { "IdMensaje", "Correo", "FechaEnvio", "Mensaje", "Remitente", "Remitio" },
                values: new object[,]
                {
                    { 1, "diego@gmail.com", new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anuel AA", "Juan", "Pedro" },
                    { 2, "die@gmail.com", new DateTime(2027, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anuela AA", "Juana", "Pedra" }
                });

            migrationBuilder.InsertData(
                table: "niveles",
                columns: new[] { "IdNivel", "NombreNivel" },
                values: new object[,]
                {
                    { 1, "pollo" },
                    { 2, "Gumball" }
                });

            migrationBuilder.InsertData(
                table: "numeros_Asignaciones",
                columns: new[] { "IdNumerosAsignaciones", "IdDocente", "NumeroAsignado" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "planEstudios",
                columns: new[] { "IdPlan", "CantidadAsignaturas", "Descripcion", "IdCarrera" },
                values: new object[,]
                {
                    { 1, 10, "Plan de Estudio 1", 1 },
                    { 2, 12, "Plan de Estudio 2", 2 }
                });

            migrationBuilder.InsertData(
                table: "planificacionTareas",
                columns: new[] { "IdPlanificacion", "CodigoTarea", "DescripcionTarea", "DescripcionUnidad", "FechaPresentacion", "FechaPublicacion", "IdAsignatura", "IdDocente", "IdNumeroAsignacion", "Tarea", "Unidad" },
                values: new object[,]
                {
                    { 1, 12345, "Descripción de la Tarea 1", "Descripción de la Unidad 1", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, "Tarea 1", "Unidad 1" },
                    { 2, 54321, "Descripción de la Tarea 2", "Descripción de la Unidad 2", new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 2, "Tarea 2", "Unidad 2" }
                });

            migrationBuilder.InsertData(
                table: "turnos",
                columns: new[] { "IdTurno", "NombreTurno" },
                values: new object[,]
                {
                    { 1, "Turno de Mañana" },
                    { 2, "Turno de Tarde" }
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "IdUsuario", "Codigo", "Foto", "NivelUsuario", "NombreUsuario", "PassUsuario" },
                values: new object[,]
                {
                    { (short)1, 12345, "usuario1.jpg", 1, "usuario1", "contraseña1" },
                    { (short)2, 54321, "usuario2.jpg", 2, "usuario2", "contraseña2" }
                });

            migrationBuilder.InsertData(
                table: "yearAcademicos",
                columns: new[] { "IdYearAcademico", "NombreYear" },
                values: new object[,]
                {
                    { 1, "2023-2024" },
                    { 2, "2024-2025" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asignaciones");

            migrationBuilder.DropTable(
                name: "asignaturas");

            migrationBuilder.DropTable(
                name: "carreras");

            migrationBuilder.DropTable(
                name: "cuatrimestres");

            migrationBuilder.DropTable(
                name: "docentes");

            migrationBuilder.DropTable(
                name: "entregaTareas");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "evaluaciones");

            migrationBuilder.DropTable(
                name: "grupos");

            migrationBuilder.DropTable(
                name: "horarios");

            migrationBuilder.DropTable(
                name: "inscripcionesAsignaturas");

            migrationBuilder.DropTable(
                name: "materialDidacticos");

            migrationBuilder.DropTable(
                name: "mensajes");

            migrationBuilder.DropTable(
                name: "niveles");

            migrationBuilder.DropTable(
                name: "numeros_Asignaciones");

            migrationBuilder.DropTable(
                name: "planEstudios");

            migrationBuilder.DropTable(
                name: "planificacionTareas");

            migrationBuilder.DropTable(
                name: "turnos");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "yearAcademicos");
        }
    }
}
