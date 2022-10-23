using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRVacancies.Migrations
{
    public partial class ChangeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HRRequisitiones",
                table: "HRRequisitiones");

            migrationBuilder.RenameTable(
                name: "HRRequisitiones",
                newName: "HRRequisitions");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "HRRequisitions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "HRRequisitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "HRRequisitions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "HRRequisitions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "HRRequisitions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HRRequisitions",
                table: "HRRequisitions",
                column: "RequisitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HRRequisitions",
                table: "HRRequisitions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "HRRequisitions");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "HRRequisitions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "HRRequisitions");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "HRRequisitions");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "HRRequisitions");

            migrationBuilder.RenameTable(
                name: "HRRequisitions",
                newName: "HRRequisitiones");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HRRequisitiones",
                table: "HRRequisitiones",
                column: "RequisitionId");
        }
    }
}
