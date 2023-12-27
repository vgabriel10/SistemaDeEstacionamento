using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaDeEstacionamento.Migrations
{
    /// <inheritdoc />
    public partial class addvlrinicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TiposVeiculos",
                columns: new[] { "Id", "Nome", "Situacao" },
                values: new object[,]
                {
                    { 1, "Moto", true },
                    { 2, "Carro", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TiposVeiculos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TiposVeiculos",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
