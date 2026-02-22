using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maksby.Migrations
{
    /// <inheritdoc />
    public partial class editSummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualDebt",
                table: "Summaries");

            migrationBuilder.RenameColumn(
                name: "Revenue",
                table: "Summaries",
                newName: "PaidForSuppliers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaidForSuppliers",
                table: "Summaries",
                newName: "Revenue");

            migrationBuilder.AddColumn<double>(
                name: "ActualDebt",
                table: "Summaries",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
