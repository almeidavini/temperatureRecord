using Microsoft.EntityFrameworkCore.Migrations;

namespace Medição.Migrations
{
    public partial class acresentandoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicoes_Pessoas_PessoaId",
                table: "Medicoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Setores_SetorId",
                table: "Pessoas");

            migrationBuilder.RenameColumn(
                name: "SetorId",
                table: "Pessoas",
                newName: "setorId");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoas_SetorId",
                table: "Pessoas",
                newName: "IX_Pessoas_setorId");

            migrationBuilder.RenameColumn(
                name: "PessoaId",
                table: "Medicoes",
                newName: "pessoaId");

            migrationBuilder.RenameIndex(
                name: "IX_Medicoes_PessoaId",
                table: "Medicoes",
                newName: "IX_Medicoes_pessoaId");

            migrationBuilder.AlterColumn<int>(
                name: "setorId",
                table: "Pessoas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "pessoaId",
                table: "Medicoes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicoes_Pessoas_pessoaId",
                table: "Medicoes",
                column: "pessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Setores_setorId",
                table: "Pessoas",
                column: "setorId",
                principalTable: "Setores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicoes_Pessoas_pessoaId",
                table: "Medicoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Setores_setorId",
                table: "Pessoas");

            migrationBuilder.RenameColumn(
                name: "setorId",
                table: "Pessoas",
                newName: "SetorId");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoas_setorId",
                table: "Pessoas",
                newName: "IX_Pessoas_SetorId");

            migrationBuilder.RenameColumn(
                name: "pessoaId",
                table: "Medicoes",
                newName: "PessoaId");

            migrationBuilder.RenameIndex(
                name: "IX_Medicoes_pessoaId",
                table: "Medicoes",
                newName: "IX_Medicoes_PessoaId");

            migrationBuilder.AlterColumn<int>(
                name: "SetorId",
                table: "Pessoas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PessoaId",
                table: "Medicoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}
