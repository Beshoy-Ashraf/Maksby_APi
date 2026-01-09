using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maksby.Migrations
{
    /// <inheritdoc />
    public partial class addSalary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salary_Employee_EmployeeId",
                table: "Salary");

            migrationBuilder.DropForeignKey(
                name: "FK_Salary_Summary_SummaryId",
                table: "Salary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salary",
                table: "Salary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Salary",
                newName: "Salaries");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_Salary_SummaryId",
                table: "Salaries",
                newName: "IX_Salaries_SummaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Salary_EmployeeId",
                table: "Salaries",
                newName: "IX_Salaries_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salaries",
                table: "Salaries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Employees_EmployeeId",
                table: "Salaries",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Summary_SummaryId",
                table: "Salaries",
                column: "SummaryId",
                principalTable: "Summary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Employees_EmployeeId",
                table: "Salaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Summary_SummaryId",
                table: "Salaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salaries",
                table: "Salaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Salaries",
                newName: "Salary");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_Salaries_SummaryId",
                table: "Salary",
                newName: "IX_Salary_SummaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Salaries_EmployeeId",
                table: "Salary",
                newName: "IX_Salary_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salary",
                table: "Salary",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Salary_Employee_EmployeeId",
                table: "Salary",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salary_Summary_SummaryId",
                table: "Salary",
                column: "SummaryId",
                principalTable: "Summary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
