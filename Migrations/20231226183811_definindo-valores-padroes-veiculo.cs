using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaDeEstacionamento.Migrations
{
    /// <inheritdoc />
    public partial class definindovalorespadroesveiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ValorVeiculo",
                columns: new[] { "Id", "IdDia", "IdTipoVeiculo", "Promocao", "ValorHora" },
                values: new object[,]
                {
                    { 1, 1, 1, null, 5m },
                    { 2, 2, 1, null, 5m },
                    { 3, 3, 1, null, 5m },
                    { 4, 4, 1, null, 5m },
                    { 5, 5, 1, null, 5m },
                    { 6, 6, 1, null, 5m },
                    { 7, 7, 1, null, 5m },
                    { 8, 8, 1, null, 5m },
                    { 9, 1, 2, null, 10m },
                    { 10, 2, 2, null, 10m },
                    { 11, 3, 2, null, 10m },
                    { 12, 4, 2, null, 10m },
                    { 13, 5, 2, null, 10m },
                    { 14, 6, 2, null, 10m },
                    { 15, 7, 2, null, 10m },
                    { 16, 8, 2, null, 10m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ValorVeiculo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ValorVeiculo",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ValorVeiculo",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ValorVeiculo",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ValorVeiculo",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ValorVeiculo",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ValorVeiculo",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ValorVeiculo",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ValorVeiculo",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ValorVeiculo",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ValorVeiculo",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ValorVeiculo",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ValorVeiculo",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ValorVeiculo",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ValorVeiculo",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ValorVeiculo",
                keyColumn: "Id",
                keyValue: 16);
        }
    }
}
