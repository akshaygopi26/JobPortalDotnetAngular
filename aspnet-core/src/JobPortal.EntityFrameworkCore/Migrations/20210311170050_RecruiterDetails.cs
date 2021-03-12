using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Migrations
{
    public partial class RecruiterDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecruiterDetailsId",
                table: "JobDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RecruiterDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecruiterID = table.Column<long>(type: "bigint", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruiterDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecruiterDetails_AbpUsers_RecruiterID",
                        column: x => x.RecruiterID,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobDetails_RecruiterDetailsId",
                table: "JobDetails",
                column: "RecruiterDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruiterDetails_RecruiterID",
                table: "RecruiterDetails",
                column: "RecruiterID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobDetails_RecruiterDetails_RecruiterDetailsId",
                table: "JobDetails",
                column: "RecruiterDetailsId",
                principalTable: "RecruiterDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobDetails_RecruiterDetails_RecruiterDetailsId",
                table: "JobDetails");

            migrationBuilder.DropTable(
                name: "RecruiterDetails");

            migrationBuilder.DropIndex(
                name: "IX_JobDetails_RecruiterDetailsId",
                table: "JobDetails");

            migrationBuilder.DropColumn(
                name: "RecruiterDetailsId",
                table: "JobDetails");
        }
    }
}
