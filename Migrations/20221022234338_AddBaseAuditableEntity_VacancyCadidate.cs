using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRVacancies.Migrations
{
    public partial class AddBaseAuditableEntity_VacancyCadidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "VacancyCadidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "VacancyCadidates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VacancyCadidates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "VacancyCadidates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "VacancyCadidates",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "VacancyCadidates");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "VacancyCadidates");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VacancyCadidates");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "VacancyCadidates");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "VacancyCadidates");
        }
    }
}
