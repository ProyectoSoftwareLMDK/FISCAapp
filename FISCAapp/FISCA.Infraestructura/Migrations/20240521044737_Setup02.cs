using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FISCA.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class Setup02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "inscripcionesAsignaturas",
                columns: new[] { "IdInscripcion", "FechaInscripcion", "IdAsignatura", "IdEstudiante", "Observaciones" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "JAJAJAJA" },
                    { 2, new DateTime(2025, 2, 1, 0, 0, 0, 02, DateTimeKind.Unspecified), 2, 2, "JEJEJEJE" }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
