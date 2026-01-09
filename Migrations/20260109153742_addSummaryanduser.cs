using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maksby.Migrations
{
    /// <inheritdoc />
    public partial class addSummaryanduser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientInvoices_Summary_SummaryId",
                table: "ClientInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtInvoices_Summary_SummaryId",
                table: "DebtInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Summary_SummaryId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Summary_SummaryId",
                table: "Salaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Summary",
                table: "Summary");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Summary",
                newName: "Summaries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Summaries",
                table: "Summaries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientInvoices_Summaries_SummaryId",
                table: "ClientInvoices",
                column: "SummaryId",
                principalTable: "Summaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtInvoices_Summaries_SummaryId",
                table: "DebtInvoices",
                column: "SummaryId",
                principalTable: "Summaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Summaries_SummaryId",
                table: "Expenses",
                column: "SummaryId",
                principalTable: "Summaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Summaries_SummaryId",
                table: "Salaries",
                column: "SummaryId",
                principalTable: "Summaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientInvoices_Summaries_SummaryId",
                table: "ClientInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtInvoices_Summaries_SummaryId",
                table: "DebtInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Summaries_SummaryId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Summaries_SummaryId",
                table: "Salaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Summaries",
                table: "Summaries");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Summaries",
                newName: "Summary");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Summary",
                table: "Summary",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientInvoices_Summary_SummaryId",
                table: "ClientInvoices",
                column: "SummaryId",
                principalTable: "Summary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtInvoices_Summary_SummaryId",
                table: "DebtInvoices",
                column: "SummaryId",
                principalTable: "Summary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Summary_SummaryId",
                table: "Expenses",
                column: "SummaryId",
                principalTable: "Summary",
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
    }
}
