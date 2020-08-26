using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Medição.Migrations
{
    public partial class AddDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DtMedicao",
                table: "Medicoes",
                type: "dateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DtMedicao",
                table: "Medicoes",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "dateTime");
        }
    }
}
