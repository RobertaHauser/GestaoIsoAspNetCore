using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoIso.Migrations
{
    public partial class FuncionarioPessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Funcionario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Funcionario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
