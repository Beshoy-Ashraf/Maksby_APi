using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maksby.Migrations
{
    /// <inheritdoc />
    public partial class addDebt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchItems_Item_ItemId",
                table: "BatchItems");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtInvoice_Summary_SummaryId",
                table: "DebtInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtInvoice_Supplier_SupplierId",
                table: "DebtInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtInvoiceItem_DebtInvoice_DebtInvoiceId",
                table: "DebtInvoiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtInvoiceItem_Item_ItemsId",
                table: "DebtInvoiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtTransaction_DebtInvoice_DebtInvoiceId",
                table: "DebtTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtTransaction_Supplier_SupplierId",
                table: "DebtTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DebtTransaction",
                table: "DebtTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DebtInvoice",
                table: "DebtInvoice");

            migrationBuilder.RenameTable(
                name: "Supplier",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "DebtTransaction",
                newName: "DebtTransactions");

            migrationBuilder.RenameTable(
                name: "DebtInvoice",
                newName: "DebtInvoices");

            migrationBuilder.RenameIndex(
                name: "IX_DebtTransaction_SupplierId",
                table: "DebtTransactions",
                newName: "IX_DebtTransactions_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_DebtTransaction_DebtInvoiceId",
                table: "DebtTransactions",
                newName: "IX_DebtTransactions_DebtInvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_DebtInvoice_SupplierId",
                table: "DebtInvoices",
                newName: "IX_DebtInvoices_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_DebtInvoice_SummaryId",
                table: "DebtInvoices",
                newName: "IX_DebtInvoices_SummaryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DebtTransactions",
                table: "DebtTransactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DebtInvoices",
                table: "DebtInvoices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchItems_Items_ItemId",
                table: "BatchItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtInvoiceItem_DebtInvoices_DebtInvoiceId",
                table: "DebtInvoiceItem",
                column: "DebtInvoiceId",
                principalTable: "DebtInvoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtInvoiceItem_Items_ItemsId",
                table: "DebtInvoiceItem",
                column: "ItemsId",
                principalTable: "Items",
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
                name: "FK_DebtInvoices_Suppliers_SupplierId",
                table: "DebtInvoices",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtTransactions_DebtInvoices_DebtInvoiceId",
                table: "DebtTransactions",
                column: "DebtInvoiceId",
                principalTable: "DebtInvoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtTransactions_Suppliers_SupplierId",
                table: "DebtTransactions",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchItems_Items_ItemId",
                table: "BatchItems");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtInvoiceItem_DebtInvoices_DebtInvoiceId",
                table: "DebtInvoiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtInvoiceItem_Items_ItemsId",
                table: "DebtInvoiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtInvoices_Summary_SummaryId",
                table: "DebtInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtInvoices_Suppliers_SupplierId",
                table: "DebtInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtTransactions_DebtInvoices_DebtInvoiceId",
                table: "DebtTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtTransactions_Suppliers_SupplierId",
                table: "DebtTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DebtTransactions",
                table: "DebtTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DebtInvoices",
                table: "DebtInvoices");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Supplier");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameTable(
                name: "DebtTransactions",
                newName: "DebtTransaction");

            migrationBuilder.RenameTable(
                name: "DebtInvoices",
                newName: "DebtInvoice");

            migrationBuilder.RenameIndex(
                name: "IX_DebtTransactions_SupplierId",
                table: "DebtTransaction",
                newName: "IX_DebtTransaction_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_DebtTransactions_DebtInvoiceId",
                table: "DebtTransaction",
                newName: "IX_DebtTransaction_DebtInvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_DebtInvoices_SupplierId",
                table: "DebtInvoice",
                newName: "IX_DebtInvoice_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_DebtInvoices_SummaryId",
                table: "DebtInvoice",
                newName: "IX_DebtInvoice_SummaryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DebtTransaction",
                table: "DebtTransaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DebtInvoice",
                table: "DebtInvoice",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchItems_Item_ItemId",
                table: "BatchItems",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtInvoice_Summary_SummaryId",
                table: "DebtInvoice",
                column: "SummaryId",
                principalTable: "Summary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtInvoice_Supplier_SupplierId",
                table: "DebtInvoice",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtInvoiceItem_DebtInvoice_DebtInvoiceId",
                table: "DebtInvoiceItem",
                column: "DebtInvoiceId",
                principalTable: "DebtInvoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtInvoiceItem_Item_ItemsId",
                table: "DebtInvoiceItem",
                column: "ItemsId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtTransaction_DebtInvoice_DebtInvoiceId",
                table: "DebtTransaction",
                column: "DebtInvoiceId",
                principalTable: "DebtInvoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtTransaction_Supplier_SupplierId",
                table: "DebtTransaction",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
