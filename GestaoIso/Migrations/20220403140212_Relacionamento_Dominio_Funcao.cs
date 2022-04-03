using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoIso.Migrations
{
    public partial class Relacionamento_Dominio_Funcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcao_Dominio_DominioId",
                table: "Funcao");

            migrationBuilder.DropIndex(
                name: "IX_Funcao_DominioId",
                table: "Funcao");

            migrationBuilder.DropColumn(
                name: "DominioId",
                table: "Funcao");

            migrationBuilder.DropColumn(
                name: "Educacao",
                table: "Funcao");

            migrationBuilder.AddColumn<int>(
                name: "DominioIdEducacao",
                table: "Funcao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Funcao_DominioIdEducacao",
                table: "Funcao",
                column: "DominioIdEducacao");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcao_Dominio_DominioIdEducacao",
                table: "Funcao",
                column: "DominioIdEducacao",
                principalTable: "Dominio",
                principalColumn: "DominioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcao_Dominio_DominioIdEducacao",
                table: "Funcao");

            migrationBuilder.DropIndex(
                name: "IX_Funcao_DominioIdEducacao",
                table: "Funcao");

            migrationBuilder.DropColumn(
                name: "DominioIdEducacao",
                table: "Funcao");

            migrationBuilder.AddColumn<int>(
                name: "DominioId",
                table: "Funcao",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Educacao",
                table: "Funcao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Funcao_DominioId",
                table: "Funcao",
                column: "DominioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcao_Dominio_DominioId",
                table: "Funcao",
                column: "DominioId",
                principalTable: "Dominio",
                principalColumn: "DominioId");
        }
    }
}
