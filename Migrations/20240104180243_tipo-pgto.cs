using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaDeEstacionamento.Migrations
{
    /// <inheritdoc />
    public partial class tipopgto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TiposPagamentos",
                columns: new[] { "Id", "FormaPagamento" },
                values: new object[,]
                {
                    { 1, "Dinheiro" },
                    { 2, "Pix" },
                    { 3, "Cartão de débito" },
                    { 4, "Cartão de crédito" },
                    { 5, "Boleto" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TiposPagamentos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TiposPagamentos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TiposPagamentos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TiposPagamentos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TiposPagamentos",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
