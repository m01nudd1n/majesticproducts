using Microsoft.EntityFrameworkCore.Migrations;

namespace Majestic.Domain.Migrations
{
    public partial class OrderIdInDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Details",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Details_OrderId",
                table: "Details",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Orders_OrderId",
                table: "Details",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_Orders_OrderId",
                table: "Details");

            migrationBuilder.DropIndex(
                name: "IX_Details_OrderId",
                table: "Details");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Details");
        }
    }
}
