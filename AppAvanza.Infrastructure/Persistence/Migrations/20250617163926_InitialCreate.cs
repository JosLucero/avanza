using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAvanza.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Niveles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ObjetivoCentral = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActividadesSemanales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaSemana = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NivelId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DescripcionPractica = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    LogroEsperado = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadesSemanales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActividadesSemanales_Niveles_NivelId",
                        column: x => x.NivelId,
                        principalTable: "Niveles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HitosDeDominio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NivelId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HitosDeDominio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HitosDeDominio_Niveles_NivelId",
                        column: x => x.NivelId,
                        principalTable: "Niveles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aprendices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FacilitadorId = table.Column<int>(type: "int", nullable: false),
                    NivelActualId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aprendices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aprendices_Niveles_NivelActualId",
                        column: x => x.NivelActualId,
                        principalTable: "Niveles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aprendices_Usuarios_FacilitadorId",
                        column: x => x.FacilitadorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElementosParkingFrustracion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AprendizId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Aparcado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementosParkingFrustracion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElementosParkingFrustracion_Aprendices_AprendizId",
                        column: x => x.AprendizId,
                        principalTable: "Aprendices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AprendizId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logros_Aprendices_AprendizId",
                        column: x => x.AprendizId,
                        principalTable: "Aprendices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgresosHitos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AprendizId = table.Column<int>(type: "int", nullable: false),
                    HitoDeDominioId = table.Column<int>(type: "int", nullable: false),
                    Completado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCompletado = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgresosHitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgresosHitos_Aprendices_AprendizId",
                        column: x => x.AprendizId,
                        principalTable: "Aprendices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgresosHitos_HitosDeDominio_HitoDeDominioId",
                        column: x => x.HitoDeDominioId,
                        principalTable: "HitosDeDominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosDiarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AprendizId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosDiarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrosDiarios_Aprendices_AprendizId",
                        column: x => x.AprendizId,
                        principalTable: "Aprendices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActividadesSemanales_NivelId",
                table: "ActividadesSemanales",
                column: "NivelId");

            migrationBuilder.CreateIndex(
                name: "IX_Aprendices_FacilitadorId",
                table: "Aprendices",
                column: "FacilitadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Aprendices_NivelActualId",
                table: "Aprendices",
                column: "NivelActualId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementosParkingFrustracion_AprendizId",
                table: "ElementosParkingFrustracion",
                column: "AprendizId");

            migrationBuilder.CreateIndex(
                name: "IX_HitosDeDominio_NivelId",
                table: "HitosDeDominio",
                column: "NivelId");

            migrationBuilder.CreateIndex(
                name: "IX_Logros_AprendizId",
                table: "Logros",
                column: "AprendizId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgresosHitos_AprendizId",
                table: "ProgresosHitos",
                column: "AprendizId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgresosHitos_HitoDeDominioId",
                table: "ProgresosHitos",
                column: "HitoDeDominioId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosDiarios_AprendizId",
                table: "RegistrosDiarios",
                column: "AprendizId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActividadesSemanales");

            migrationBuilder.DropTable(
                name: "ElementosParkingFrustracion");

            migrationBuilder.DropTable(
                name: "Logros");

            migrationBuilder.DropTable(
                name: "ProgresosHitos");

            migrationBuilder.DropTable(
                name: "RegistrosDiarios");

            migrationBuilder.DropTable(
                name: "HitosDeDominio");

            migrationBuilder.DropTable(
                name: "Aprendices");

            migrationBuilder.DropTable(
                name: "Niveles");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
