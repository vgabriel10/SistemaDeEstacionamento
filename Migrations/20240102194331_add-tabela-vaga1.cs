using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeEstacionamento.Migrations
{
    /// <inheritdoc />
    public partial class addtabelavaga1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vagas",
                columns: table => new
                {
                    TotalVagas = table.Column<int>(type: "int", nullable: false),
                    VagasDiponiveis = table.Column<int>(type: "int", nullable: false),
                    VagasOcupadas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vagas");
        }
    }
}
