using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Migrations
{
    public partial class updatedUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RecruiterDetails_RecruiterID",
                table: "RecruiterDetails");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantDetails_ApplicantID",
                table: "ApplicantDetails");

            migrationBuilder.CreateIndex(
                name: "IX_RecruiterDetails_RecruiterID",
                table: "RecruiterDetails",
                column: "RecruiterID",
                unique: true,
                filter: "[RecruiterID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDetails_ApplicantID",
                table: "ApplicantDetails",
                column: "ApplicantID",
                unique: true,
                filter: "[ApplicantID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RecruiterDetails_RecruiterID",
                table: "RecruiterDetails");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantDetails_ApplicantID",
                table: "ApplicantDetails");

            migrationBuilder.CreateIndex(
                name: "IX_RecruiterDetails_RecruiterID",
                table: "RecruiterDetails",
                column: "RecruiterID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDetails_ApplicantID",
                table: "ApplicantDetails",
                column: "ApplicantID");
        }
    }
}
