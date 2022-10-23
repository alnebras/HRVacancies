using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRVacancies.Migrations
{
    public partial class InheritTableBaseAuditableTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VacancyDescription",
                table: "HRManagerVacancies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "HRManagerVacancies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "HRManagerVacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "HRManagerVacancies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "HRManagerVacancies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "HRManagerVacancies",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "HRManagerVacancies");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "HRManagerVacancies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "HRManagerVacancies");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "HRManagerVacancies");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "HRManagerVacancies");

            migrationBuilder.AlterColumn<string>(
                name: "VacancyDescription",
                table: "HRManagerVacancies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
