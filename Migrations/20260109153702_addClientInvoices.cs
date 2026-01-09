using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maksby.Migrations
{
    /// <inheritdoc />
    public partial class addClientInvoices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Product_ProductId",
                table: "Batches");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientInvoice_Client_ClientId",
                table: "ClientInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientInvoice_Summary_SummaryId",
                table: "ClientInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientInvoiceProduct_ClientInvoice_ClientInvoiceId",
                table: "ClientInvoiceProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientInvoiceProduct_Product_ProductId",
                table: "ClientInvoiceProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientTransaction_ClientInvoice_ClientInvoiceId",
                table: "ClientTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientTransaction_Client_ClientId",
                table: "ClientTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientTransaction",
                table: "ClientTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientInvoiceProduct",
                table: "ClientInvoiceProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientInvoice",
                table: "ClientInvoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "ClientTransaction",
                newName: "ClientTransactions");

            migrationBuilder.RenameTable(
                name: "ClientInvoiceProduct",
                newName: "ClientInvoiceProducts");

            migrationBuilder.RenameTable(
                name: "ClientInvoice",
                newName: "ClientInvoices");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.RenameIndex(
                name: "IX_ClientTransaction_ClientInvoiceId",
                table: "ClientTransactions",
                newName: "IX_ClientTransactions_ClientInvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientTransaction_ClientId",
                table: "ClientTransactions",
                newName: "IX_ClientTransactions_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientInvoiceProduct_ProductId",
                table: "ClientInvoiceProducts",
                newName: "IX_ClientInvoiceProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientInvoiceProduct_ClientInvoiceId",
                table: "ClientInvoiceProducts",
                newName: "IX_ClientInvoiceProducts_ClientInvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientInvoice_SummaryId",
                table: "ClientInvoices",
                newName: "IX_ClientInvoices_SummaryId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientInvoice_ClientId",
                table: "ClientInvoices",
                newName: "IX_ClientInvoices_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientTransactions",
                table: "ClientTransactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientInvoiceProducts",
                table: "ClientInvoiceProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientInvoices",
                table: "ClientInvoices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Products_ProductId",
                table: "Batches",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientInvoiceProducts_ClientInvoices_ClientInvoiceId",
                table: "ClientInvoiceProducts",
                column: "ClientInvoiceId",
                principalTable: "ClientInvoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientInvoiceProducts_Products_ProductId",
                table: "ClientInvoiceProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientInvoices_Clients_ClientId",
                table: "ClientInvoices",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientInvoices_Summary_SummaryId",
                table: "ClientInvoices",
                column: "SummaryId",
                principalTable: "Summary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTransactions_ClientInvoices_ClientInvoiceId",
                table: "ClientTransactions",
                column: "ClientInvoiceId",
                principalTable: "ClientInvoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTransactions_Clients_ClientId",
                table: "ClientTransactions",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Products_ProductId",
                table: "Batches");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientInvoiceProducts_ClientInvoices_ClientInvoiceId",
                table: "ClientInvoiceProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientInvoiceProducts_Products_ProductId",
                table: "ClientInvoiceProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientInvoices_Clients_ClientId",
                table: "ClientInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientInvoices_Summary_SummaryId",
                table: "ClientInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientTransactions_ClientInvoices_ClientInvoiceId",
                table: "ClientTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientTransactions_Clients_ClientId",
                table: "ClientTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientTransactions",
                table: "ClientTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientInvoices",
                table: "ClientInvoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientInvoiceProducts",
                table: "ClientInvoiceProducts");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "ClientTransactions",
                newName: "ClientTransaction");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.RenameTable(
                name: "ClientInvoices",
                newName: "ClientInvoice");

            migrationBuilder.RenameTable(
                name: "ClientInvoiceProducts",
                newName: "ClientInvoiceProduct");

            migrationBuilder.RenameIndex(
                name: "IX_ClientTransactions_ClientInvoiceId",
                table: "ClientTransaction",
                newName: "IX_ClientTransaction_ClientInvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientTransactions_ClientId",
                table: "ClientTransaction",
                newName: "IX_ClientTransaction_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientInvoices_SummaryId",
                table: "ClientInvoice",
                newName: "IX_ClientInvoice_SummaryId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientInvoices_ClientId",
                table: "ClientInvoice",
                newName: "IX_ClientInvoice_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientInvoiceProducts_ProductId",
                table: "ClientInvoiceProduct",
                newName: "IX_ClientInvoiceProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientInvoiceProducts_ClientInvoiceId",
                table: "ClientInvoiceProduct",
                newName: "IX_ClientInvoiceProduct_ClientInvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientTransaction",
                table: "ClientTransaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientInvoice",
                table: "ClientInvoice",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientInvoiceProduct",
                table: "ClientInvoiceProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Product_ProductId",
                table: "Batches",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientInvoice_Client_ClientId",
                table: "ClientInvoice",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientInvoice_Summary_SummaryId",
                table: "ClientInvoice",
                column: "SummaryId",
                principalTable: "Summary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientInvoiceProduct_ClientInvoice_ClientInvoiceId",
                table: "ClientInvoiceProduct",
                column: "ClientInvoiceId",
                principalTable: "ClientInvoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientInvoiceProduct_Product_ProductId",
                table: "ClientInvoiceProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTransaction_ClientInvoice_ClientInvoiceId",
                table: "ClientTransaction",
                column: "ClientInvoiceId",
                principalTable: "ClientInvoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTransaction_Client_ClientId",
                table: "ClientTransaction",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
