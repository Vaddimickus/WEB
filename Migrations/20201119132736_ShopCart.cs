using Microsoft.EntityFrameworkCore.Migrations;

namespace BicycleShop.Migrations
{
    public partial class ShopCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItems_Bicycle_bicycleid",
                table: "ShopCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopCartItems",
                table: "ShopCartItems");

            migrationBuilder.RenameTable(
                name: "ShopCartItems",
                newName: "ShopCartItem");

            migrationBuilder.RenameColumn(
                name: "ShopBicycleId",
                table: "ShopCartItem",
                newName: "ShopCartId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCartItems_bicycleid",
                table: "ShopCartItem",
                newName: "IX_ShopCartItem_bicycleid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopCartItem",
                table: "ShopCartItem",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItem_Bicycle_bicycleid",
                table: "ShopCartItem",
                column: "bicycleid",
                principalTable: "Bicycle",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItem_Bicycle_bicycleid",
                table: "ShopCartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopCartItem",
                table: "ShopCartItem");

            migrationBuilder.RenameTable(
                name: "ShopCartItem",
                newName: "ShopCartItems");

            migrationBuilder.RenameColumn(
                name: "ShopCartId",
                table: "ShopCartItems",
                newName: "ShopBicycleId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCartItem_bicycleid",
                table: "ShopCartItems",
                newName: "IX_ShopCartItems_bicycleid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopCartItems",
                table: "ShopCartItems",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItems_Bicycle_bicycleid",
                table: "ShopCartItems",
                column: "bicycleid",
                principalTable: "Bicycle",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
