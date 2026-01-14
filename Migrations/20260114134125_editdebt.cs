using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maksby.Migrations
{
    /// <inheritdoc />
    public partial class editdebt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtInvoiceItem_Items_ItemsId",
                table: "DebtInvoiceItem");

            migrationBuilder.RenameColumn(
                name: "ItemsId",
                table: "DebtInvoiceItem",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_DebtInvoiceItem_ItemsId",
                table: "DebtInvoiceItem",
                newName: "IX_DebtInvoiceItem_ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtInvoiceItem_Items_ItemId",
                table: "DebtInvoiceItem",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtInvoiceItem_Items_ItemId",
                table: "DebtInvoiceItem");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "DebtInvoiceItem",
                newName: "ItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_DebtInvoiceItem_ItemId",
                table: "DebtInvoiceItem",
                newName: "IX_DebtInvoiceItem_ItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtInvoiceItem_Items_ItemsId",
                table: "DebtInvoiceItem",
                column: "ItemsId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
