using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoIso.Migrations
{
    public partial class UsuarioController_ViewUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CriacaoResp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriacaoData = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevisaoResp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevisaoData = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UserName",
                table: "Usuario",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
