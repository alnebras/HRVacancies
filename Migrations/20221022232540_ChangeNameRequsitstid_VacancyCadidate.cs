using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRVacancies.Migrations
{
    public partial class ChangeNameRequsitstid_VacancyCadidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HRManagerVacancyId",
                table: "VacancyCadidates",
                newName: "RequisitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequisitionId",
                table: "VacancyCadidates",
                newName: "HRManagerVacancyId");
        }
    }
}
