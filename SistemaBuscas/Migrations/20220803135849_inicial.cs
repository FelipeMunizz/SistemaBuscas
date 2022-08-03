using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaBuscas.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condominios",
                columns: table => new
                {
                    CondominioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Complemento = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TelAdm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TelPort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TelZela = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SenhaBoletos = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominios", x => x.CondominioId);
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    ContatoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    Residencial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comercial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.ContatoId);
                });

            migrationBuilder.CreateTable(
                name: "Debitos",
                columns: table => new
                {
                    DebitoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Servico = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroDeb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debitos", x => x.DebitoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Condominios");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Debitos");
        }
    }
}
