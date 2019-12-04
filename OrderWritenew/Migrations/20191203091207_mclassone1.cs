using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderWritenew.Migrations
{
    public partial class mclassone1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInfo_orders_Orderid",
                table: "CustomerInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLineItems_orders_Orderid",
                table: "OrderLineItems");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInfo_orders_Orderid",
                table: "CustomerInfo",
                column: "Orderid",
                principalTable: "orders",
                principalColumn: "Orderid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLineItems_orders_Orderid",
                table: "OrderLineItems",
                column: "Orderid",
                principalTable: "orders",
                principalColumn: "Orderid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInfo_orders_Orderid",
                table: "CustomerInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLineItems_orders_Orderid",
                table: "OrderLineItems");

            migrationBuilder.DropColumn(
                name: "State",
                table: "orders");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInfo_orders_Orderid",
                table: "CustomerInfo",
                column: "Orderid",
                principalTable: "orders",
                principalColumn: "Orderid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLineItems_orders_Orderid",
                table: "OrderLineItems",
                column: "Orderid",
                principalTable: "orders",
                principalColumn: "Orderid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
