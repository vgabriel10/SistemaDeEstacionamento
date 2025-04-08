using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeEstacionamento.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoIdTabelaVagas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Vagas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vagas",
                table: "Vagas",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Vagas",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Vagas");
        }
    }
}
