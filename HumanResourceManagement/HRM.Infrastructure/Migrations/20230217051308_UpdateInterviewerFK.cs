using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInterviewerFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interview_Employee_EmployeeId",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Interview_EmployeeId",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Interview");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_InterviewerId",
                table: "Interview",
                column: "InterviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_Employee_InterviewerId",
                table: "Interview",
                column: "InterviewerId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interview_Employee_InterviewerId",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Interview_InterviewerId",
                table: "Interview");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Interview",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Interview_EmployeeId",
                table: "Interview",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_Employee_EmployeeId",
                table: "Interview",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
