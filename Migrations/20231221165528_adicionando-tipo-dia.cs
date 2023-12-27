using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeEstacionamento.Migrations
{
    /// <inheritdoc />
    public partial class adicionandotipodia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientesVeiculosValores_TiposVeiculos_IdTipo",
                table: "ClientesVeiculosValores");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_TiposVeiculos_IdTipo",
                table: "Veiculos");

            migrationBuilder.RenameColumn(
                name: "IdTipo",
                table: "Veiculos",
                newName: "IdTipoVeiculo");

            migrationBuilder.RenameIndex(
                name: "IX_Veiculos_IdTipo",
                table: "Veiculos",
                newName: "IX_Veiculos_IdTipoVeiculo");

            migrationBuilder.RenameColumn(
                name: "IdTipo",
                table: "ClientesVeiculosValores",
                newName: "IdTipoVeiculo");

            migrationBuilder.RenameIndex(
                name: "IX_ClientesVeiculosValores_IdTipo",
                table: "ClientesVeiculosValores",
                newName: "IX_ClientesVeiculosValores_IdTipoVeiculo");

            migrationBuilder.AddColumn<int>(
                name: "IdTipoDia",
                table: "Veiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_IdTipoDia",
                table: "Veiculos",
                column: "IdTipoDia");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesVeiculosValores_TiposVeiculos_IdTipoVeiculo",
                table: "ClientesVeiculosValores",
                column: "IdTipoVeiculo",
                principalTable: "TiposVeiculos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_TiposDias_IdTipoDia",
                table: "Veiculos",
                column: "IdTipoDia",
                principalTable: "TiposDias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_TiposVeiculos_IdTipoVeiculo",
                table: "Veiculos",
                column: "IdTipoVeiculo",
                principalTable: "TiposVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientesVeiculosValores_TiposVeiculos_IdTipoVeiculo",
                table: "ClientesVeiculosValores");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_TiposDias_IdTipoDia",
                table: "Veiculos");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_TiposVeiculos_IdTipoVeiculo",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_IdTipoDia",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "IdTipoDia",
                table: "Veiculos");

            migrationBuilder.RenameColumn(
                name: "IdTipoVeiculo",
                table: "Veiculos",
                newName: "IdTipo");

            migrationBuilder.RenameIndex(
                name: "IX_Veiculos_IdTipoVeiculo",
                table: "Veiculos",
                newName: "IX_Veiculos_IdTipo");

            migrationBuilder.RenameColumn(
                name: "IdTipoVeiculo",
                table: "ClientesVeiculosValores",
                newName: "IdTipo");

            migrationBuilder.RenameIndex(
                name: "IX_ClientesVeiculosValores_IdTipoVeiculo",
                table: "ClientesVeiculosValores",
                newName: "IX_ClientesVeiculosValores_IdTipo");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesVeiculosValores_TiposVeiculos_IdTipo",
                table: "ClientesVeiculosValores",
                column: "IdTipo",
                principalTable: "TiposVeiculos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_TiposVeiculos_IdTipo",
                table: "Veiculos",
                column: "IdTipo",
                principalTable: "TiposVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
