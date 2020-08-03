using Microsoft.EntityFrameworkCore.Migrations;

namespace Medição.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Setores",
                columns: table => new
                {
                    IdSetor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setores", x => x.IdSetor);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Idpessoa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: true),
                    Sobrenome = table.Column<string>(maxLength: 200, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SetorIdSetor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Idpessoa);
                    table.ForeignKey(
                        name: "FK_Pessoas_Setores_SetorIdSetor",
                        column: x => x.SetorIdSetor,
                        principalTable: "Setores",
                        principalColumn: "IdSetor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicoes",
                columns: table => new
                {
                    IdMedicao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaIdpessoa = table.Column<int>(nullable: true),
                    Temperatura = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicoes", x => x.IdMedicao);
                    table.ForeignKey(
                        name: "FK_Medicoes_Pessoas_PessoaIdpessoa",
                        column: x => x.PessoaIdpessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Idpessoa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicoes_PessoaIdpessoa",
                table: "Medicoes",
                column: "PessoaIdpessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_SetorIdSetor",
                table: "Pessoas",
                column: "SetorIdSetor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicoes");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Setores");
        }
    }
}
