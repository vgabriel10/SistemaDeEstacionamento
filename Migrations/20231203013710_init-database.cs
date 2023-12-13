using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeEstacionamento.Migrations
{
    /// <inheritdoc />
    public partial class initdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposVeiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposVeiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValorVeiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoVeiculo = table.Column<int>(type: "int", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    ValorHora = table.Column<float>(type: "real", nullable: false),
                    Promocao = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValorVeiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValorVeiculo_TiposVeiculos_IdTipoVeiculo",
                        column: x => x.IdTipoVeiculo,
                        principalTable: "TiposVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipo = table.Column<int>(type: "int", nullable: false),
                    HoraEntrada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraSaida = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculos_TiposVeiculos_IdTipo",
                        column: x => x.IdTipo,
                        principalTable: "TiposVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdVeiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Veiculos_IdVeiculo",
                        column: x => x.IdVeiculo,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientesVeiculosValores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdTipo = table.Column<int>(type: "int", nullable: true),
                    IdVeiculo = table.Column<int>(type: "int", nullable: true),
                    TempoEstacionado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorBruto = table.Column<float>(type: "real", nullable: false),
                    ValorTotal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesVeiculosValores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientesVeiculosValores_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientesVeiculosValores_TiposVeiculos_IdTipo",
                        column: x => x.IdTipo,
                        principalTable: "TiposVeiculos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClientesVeiculosValores_Veiculos_IdVeiculo",
                        column: x => x.IdVeiculo,
                        principalTable: "Veiculos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdVeiculo",
                table: "Clientes",
                column: "IdVeiculo");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesVeiculosValores_IdCliente",
                table: "ClientesVeiculosValores",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesVeiculosValores_IdTipo",
                table: "ClientesVeiculosValores",
                column: "IdTipo");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesVeiculosValores_IdVeiculo",
                table: "ClientesVeiculosValores",
                column: "IdVeiculo");

            migrationBuilder.CreateIndex(
                name: "IX_ValorVeiculo_IdTipoVeiculo",
                table: "ValorVeiculo",
                column: "IdTipoVeiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_IdTipo",
                table: "Veiculos",
                column: "IdTipo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientesVeiculosValores");

            migrationBuilder.DropTable(
                name: "ValorVeiculo");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "TiposVeiculos");
        }
    }
}
