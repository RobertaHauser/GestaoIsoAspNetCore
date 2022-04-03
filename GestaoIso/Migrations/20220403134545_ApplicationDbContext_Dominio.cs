using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoIso.Migrations
{
    public partial class ApplicationDbContext_Dominio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcao",
                columns: table => new
                {
                    FuncaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cargo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Experiencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Educacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Treinamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriacaoResp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriacaoData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevisaoResp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevisaoData = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AprovacaoStatus = table.Column<bool>(type: "bit", nullable: false),
                    AprovacaoResp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AprovacaoData = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdutoComentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DominioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcao", x => x.FuncaoId);
                    table.ForeignKey(
                        name: "FK_Funcao_Dominio_DominioId",
                        column: x => x.DominioId,
                        principalTable: "Dominio",
                        principalColumn: "DominioId");
                });

            migrationBuilder.InsertData(
                table: "Dominio",
                columns: new[] { "DominioId", "Descricao", "Ordem", "Tabela" },
                values: new object[,]
                {
                    { 1, "Analfabeto", null, "Educacao" },
                    { 2, "Alfabetizado", null, "Educacao" },
                    { 3, "Fundamental", null, "Educacao" },
                    { 4, "Médio", null, "Educacao" },
                    { 5, "Superior", null, "Educacao" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcao_Cargo",
                table: "Funcao",
                column: "Cargo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcao_DominioId",
                table: "Funcao",
                column: "DominioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcao");

            migrationBuilder.DeleteData(
                table: "Dominio",
                keyColumn: "DominioId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dominio",
                keyColumn: "DominioId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dominio",
                keyColumn: "DominioId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dominio",
                keyColumn: "DominioId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Dominio",
                keyColumn: "DominioId",
                keyValue: 5);
        }
    }
}
