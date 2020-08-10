using Microsoft.EntityFrameworkCore.Migrations;

namespace Medição.Migrations
{
    public partial class ChangingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicoes_Pessoas_PessoaIdpessoa",
                table: "Medicoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Setores_SetorIdSetor",
                table: "Pessoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Setores",
                table: "Setores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoas",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_SetorIdSetor",
                table: "Pessoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicoes",
                table: "Medicoes");

            migrationBuilder.DropIndex(
                name: "IX_Medicoes_PessoaIdpessoa",
                table: "Medicoes");

            migrationBuilder.DropColumn(
                name: "IdSetor",
                table: "Setores");

            migrationBuilder.DropColumn(
                name: "Idpessoa",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "SetorIdSetor",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "IdMedicao",
                table: "Medicoes");

            migrationBuilder.DropColumn(
                name: "PessoaIdpessoa",
                table: "Medicoes");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Setores",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Pessoas",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SetorId",
                table: "Pessoas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Medicoes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Medicoes",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Setores",
                table: "Setores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoas",
                table: "Pessoas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicoes",
                table: "Medicoes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_SetorId",
                table: "Pessoas",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicoes_PessoaId",
                table: "Medicoes",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicoes_Pessoas_PessoaId",
                table: "Medicoes",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Setores_SetorId",
                table: "Pessoas",
                column: "SetorId",
                principalTable: "Setores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicoes_Pessoas_PessoaId",
                table: "Medicoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Setores_SetorId",
                table: "Pessoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Setores",
                table: "Setores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoas",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_SetorId",
                table: "Pessoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicoes",
                table: "Medicoes");

            migrationBuilder.DropIndex(
                name: "IX_Medicoes_PessoaId",
                table: "Medicoes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Setores");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "SetorId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Medicoes");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Medicoes");

            migrationBuilder.AddColumn<int>(
                name: "IdSetor",
                table: "Setores",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Idpessoa",
                table: "Pessoas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SetorIdSetor",
                table: "Pessoas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdMedicao",
                table: "Medicoes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PessoaIdpessoa",
                table: "Medicoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Setores",
                table: "Setores",
                column: "IdSetor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoas",
                table: "Pessoas",
                column: "Idpessoa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicoes",
                table: "Medicoes",
                column: "IdMedicao");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_SetorIdSetor",
                table: "Pessoas",
                column: "SetorIdSetor");

            migrationBuilder.CreateIndex(
                name: "IX_Medicoes_PessoaIdpessoa",
                table: "Medicoes",
                column: "PessoaIdpessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicoes_Pessoas_PessoaIdpessoa",
                table: "Medicoes",
                column: "PessoaIdpessoa",
                principalTable: "Pessoas",
                principalColumn: "Idpessoa",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Setores_SetorIdSetor",
                table: "Pessoas",
                column: "SetorIdSetor",
                principalTable: "Setores",
                principalColumn: "IdSetor",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
