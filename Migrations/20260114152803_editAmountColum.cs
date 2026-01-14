using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maksby.Migrations
{
    /// <inheritdoc />
    public partial class editAmountColum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "DebtInvoiceItem",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "DebtInvoiceItem");
        }
    }
}
