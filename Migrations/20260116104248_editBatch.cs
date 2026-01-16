using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maksby.Migrations
{
    /// <inheritdoc />
    public partial class editBatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Batches");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Batches",
                newName: "UpdatedDate");

            migrationBuilder.AddColumn<int>(
                name: "BatchStatus",
                table: "Batches",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Batches",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Batches",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "ProductQuantity",
                table: "Batches",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchStatus",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "ProductQuantity",
                table: "Batches");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Batches",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Batches",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
