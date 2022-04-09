using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoIso.Migrations
{
    public partial class DataFuncionario_InclusaoCamposCriacaoRevisao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CriacaoData",
                table: "Funcionario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CriacaoResp",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RevisaoData",
                table: "Funcionario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RevisaoResp",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriacaoData",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "CriacaoResp",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "RevisaoData",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "RevisaoResp",
                table: "Funcionario");
        }
    }
}
