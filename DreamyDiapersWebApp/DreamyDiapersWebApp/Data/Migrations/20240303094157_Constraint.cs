using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamyDiapersWebApp.Migrations
{
    /// <inheritdoc />
    public partial class Constraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Item_ItemId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ItemId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ItemId",
                table: "Order",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Item_ItemId",
                table: "Order",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id");
        }
    }
}
