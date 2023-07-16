using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GanheFacil.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resultados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DataSorteio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorPremio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Sorteios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    DataSorteio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumerosSorteados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoJogo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sorteios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NumeroSorteados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    SorteioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeroSorteados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NumeroSorteados_Sorteios_SorteioId",
                        column: x => x.SorteioId,
                        principalTable: "Sorteios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NumeroSorteados_SorteioId",
                table: "NumeroSorteados",
                column: "SorteioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumeroSorteados");

            migrationBuilder.DropTable(
                name: "Resultados");

            migrationBuilder.DropTable(
                name: "Sorteios");
        }
    }
}
