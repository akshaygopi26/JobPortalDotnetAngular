using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Migrations
{
    public partial class editingRecruiterApplicant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobDetails_RecruiterDetails_RecruiterDetailsId",
                table: "JobDetails");

            migrationBuilder.DropIndex(
                name: "IX_JobDetails_RecruiterDetailsId",
                table: "JobDetails");

            migrationBuilder.DropColumn(
                name: "RecruiterDetailsId",
                table: "JobDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecruiterDetailsId",
                table: "JobDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobDetails_RecruiterDetailsId",
                table: "JobDetails",
                column: "RecruiterDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobDetails_RecruiterDetails_RecruiterDetailsId",
                table: "JobDetails",
                column: "RecruiterDetailsId",
                principalTable: "RecruiterDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
