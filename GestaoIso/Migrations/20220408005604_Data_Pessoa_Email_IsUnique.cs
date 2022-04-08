using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoIso.Migrations
{
    public partial class Data_Pessoa_Email_IsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Pessoa",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_Email",
                table: "Pessoa",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pessoa_Email",
                table: "Pessoa");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Pessoa",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
