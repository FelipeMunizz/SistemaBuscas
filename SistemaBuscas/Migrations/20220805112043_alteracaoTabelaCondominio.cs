using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaBuscas.Migrations
{
    public partial class alteracaoTabelaCondominio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SenhaBoletos",
                table: "Condominios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Admininstradora",
                table: "Condominios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zelador",
                table: "Condominios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admininstradora",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Zelador",
                table: "Condominios");

            migrationBuilder.AlterColumn<string>(
                name: "SenhaBoletos",
                table: "Condominios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
