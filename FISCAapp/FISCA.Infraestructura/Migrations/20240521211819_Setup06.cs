using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FISCA.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class Setup06 : Migration
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
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDocente = table.Column<int>(type: "int", nullable: false),
                    IdAsignatura = table.Column<int>(type: "int", nullable: false),
                    IdGrupo = table.Column<int>(type: "int", nullable: false),
                    IdTurno = table.Column<int>(type: "int", nullable: false),
                    IdHorario = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    NombreAsignatura = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    NombreCarrera = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    NombreCuatrimestre = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    NombresDocente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidosDocente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CedulaDocente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoDocente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CelularDocente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoDocente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionDocente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_docentes", x => x.IdDocente);
                });

            migrationBuilder.InsertData(
                table: "asignaciones",
                columns: new[] { "IdAsignacion", "Descripcion", "Estado", "IdAsignatura", "IdDocente", "IdGrupo", "IdHorario", "IdTurno", "NumeroAsignacion" },
                values: new object[] { 1, "Waos", "Activo", 1, 1, 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "asignaturas",
                columns: new[] { "IdAsignatura", "IdCarrera", "IdCuatrimestre", "IdGrupo", "NombreAsignatura" },
                values: new object[] { 1, 1, 1, 1, "Analisis Matematico" });

            migrationBuilder.InsertData(
                table: "carreras",
                columns: new[] { "IdCarrera", "NombreCarrera" },
                values: new object[] { 1, "Waza" });

            migrationBuilder.InsertData(
                table: "cuatrimestres",
                columns: new[] { "IdCuatrimestre", "NombreCuatrimestre" },
                values: new object[] { 1, "Pruebita" });

            migrationBuilder.InsertData(
                table: "docentes",
                columns: new[] { "IdDocente", "ApellidosDocente", "CedulaDocente", "CelularDocente", "CorreoDocente", "DireccionDocente", "Estado", "Foto", "NombresDocente", "TelefonoDocente" },
                values: new object[] { 1, "Gimenez Garcilazo", "72546978", "978456123", "pedro@upla.edu.pe", "Psje. Chifuentes", 1, "", "Pedro", "064526" });
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
        }
    }
}
