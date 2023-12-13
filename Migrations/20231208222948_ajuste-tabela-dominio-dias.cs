using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeEstacionamento.Migrations
{
    /// <inheritdoc />
    public partial class ajustetabeladominiodias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TiposDias",
                columns: new[] { "Id", "Dia" },
                values: new object[] { 8, "Feriado" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TiposDias",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
