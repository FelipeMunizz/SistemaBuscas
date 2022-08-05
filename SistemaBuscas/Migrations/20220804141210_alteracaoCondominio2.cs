using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaBuscas.Migrations
{
    public partial class alteracaoCondominio2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Condominios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Condominios");
        }
    }
}
