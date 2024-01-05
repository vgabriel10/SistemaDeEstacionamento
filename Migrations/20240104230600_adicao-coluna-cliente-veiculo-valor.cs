using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeEstacionamento.Migrations
{
    /// <inheritdoc />
    public partial class adicaocolunaclienteveiculovalor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTipoPagamento",
                table: "ClientesVeiculosValores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientesVeiculosValores_IdTipoPagamento",
                table: "ClientesVeiculosValores",
                column: "IdTipoPagamento");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesVeiculosValores_TiposPagamentos_IdTipoPagamento",
                table: "ClientesVeiculosValores",
                column: "IdTipoPagamento",
                principalTable: "TiposPagamentos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientesVeiculosValores_TiposPagamentos_IdTipoPagamento",
                table: "ClientesVeiculosValores");

            migrationBuilder.DropIndex(
                name: "IX_ClientesVeiculosValores_IdTipoPagamento",
                table: "ClientesVeiculosValores");

            migrationBuilder.DropColumn(
                name: "IdTipoPagamento",
                table: "ClientesVeiculosValores");
        }
    }
}
