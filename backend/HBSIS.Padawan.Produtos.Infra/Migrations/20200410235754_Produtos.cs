using Microsoft.EntityFrameworkCore.Migrations;

namespace HBSIS.Padawan.Produtos.Infra.Migrations
{
    public partial class Produtos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FORNECEDORES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 100, nullable: false),
                    CNPJ = table.Column<string>(maxLength: 18, nullable: false),
                    NomeFantasia = table.Column<string>(maxLength: 100, nullable: true),
                    Endereco = table.Column<string>(nullable: false),
                    TelefoneDeContato = table.Column<string>(nullable: false),
                    EmailDeContato = table.Column<string>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORNECEDORES", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FORNECEDORES_CNPJ",
                table: "FORNECEDORES",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FORNECEDORES_EmailDeContato",
                table: "FORNECEDORES",
                column: "EmailDeContato",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FORNECEDORES_RazaoSocial",
                table: "FORNECEDORES",
                column: "RazaoSocial",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FORNECEDORES");
        }
    }
}
