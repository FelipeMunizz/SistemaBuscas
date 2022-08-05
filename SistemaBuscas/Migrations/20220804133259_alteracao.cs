using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaBuscas.Migrations
{
    public partial class alteracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imovel",
                table: "Debitos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imovel",
                table: "Debitos");
        }
    }
}
