using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeEstacionamento.Migrations
{
    /// <inheritdoc />
    public partial class addtabelavaga2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VagasDiponiveis",
                table: "Vagas",
                newName: "VagasDisponiveis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VagasDisponiveis",
                table: "Vagas",
                newName: "VagasDiponiveis");
        }
    }
}
