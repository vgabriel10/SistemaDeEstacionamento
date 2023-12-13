using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaDeEstacionamento.Migrations
{
    /// <inheritdoc />
    public partial class criandotabeladominiodias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dia",
                table: "ValorVeiculo",
                newName: "IdDia");

            migrationBuilder.AddColumn<string>(
                name: "LocalEstacionado",
                table: "Veiculos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Situacao",
                table: "TiposVeiculos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDePagamento",
                table: "ClientesVeiculosValores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "TiposDias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDias", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TiposDias",
                columns: new[] { "Id", "Dia" },
                values: new object[,]
                {
                    { 1, "Domingo" },
                    { 2, "Segunda Feira" },
                    { 3, "Terça Feira" },
                    { 4, "Quarta Feira" },
                    { 5, "Quinta Feira" },
                    { 6, "Sexta Feira" },
                    { 7, "Sábado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ValorVeiculo_IdDia",
                table: "ValorVeiculo",
                column: "IdDia");

            migrationBuilder.AddForeignKey(
                name: "FK_ValorVeiculo_TiposDias_IdDia",
                table: "ValorVeiculo",
                column: "IdDia",
                principalTable: "TiposDias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValorVeiculo_TiposDias_IdDia",
                table: "ValorVeiculo");

            migrationBuilder.DropTable(
                name: "TiposDias");

            migrationBuilder.DropIndex(
                name: "IX_ValorVeiculo_IdDia",
                table: "ValorVeiculo");

            migrationBuilder.DropColumn(
                name: "LocalEstacionado",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "TiposVeiculos");

            migrationBuilder.DropColumn(
                name: "DataDePagamento",
                table: "ClientesVeiculosValores");

            migrationBuilder.RenameColumn(
                name: "IdDia",
                table: "ValorVeiculo",
                newName: "Dia");
        }
    }
}
