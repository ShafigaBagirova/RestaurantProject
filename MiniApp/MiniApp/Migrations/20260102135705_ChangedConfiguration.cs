using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangedConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiningTables_Restaurant_RestaurantId",
                table: "DiningTables");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuCategory_Categories_CategoryId",
                table: "MenuCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuCategory_Menus_MenuId",
                table: "MenuCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuProduct_Menus_MenuId",
                table: "MenuProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuProduct_Products_ProductId",
                table: "MenuProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRestaurant_Products_ProductId",
                table: "ProductRestaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRestaurant_Restaurants_RestaurantId",
                table: "ProductRestaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_DiningTables_DiningTableId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCategory_Categories_CategoryId",
                table: "RestaurantCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCategory_Restaurant_RestaurantId",
                table: "RestaurantCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffRestaurant_Restaurant",
                table: "StaffRestaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffRestaurant_Staff",
                table: "StaffRestaurant");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Reservations",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RestaurantId",
                table: "Reservations",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiningTables_Restaurant_RestaurantId",
                table: "DiningTables",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuCategory_Categories_CategoryId",
                table: "MenuCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuCategory_Menus_MenuId",
                table: "MenuCategory",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuProduct_Menus_MenuId",
                table: "MenuProduct",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuProduct_Products_ProductId",
                table: "MenuProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRestaurant_Products_ProductId",
                table: "ProductRestaurant",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRestaurant_Restaurants_RestaurantId",
                table: "ProductRestaurant",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_DiningTables_DiningTableId",
                table: "Reservations",
                column: "DiningTableId",
                principalTable: "DiningTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Restaurant_RestaurantId",
                table: "Reservations",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantCategory_Categories_CategoryId",
                table: "RestaurantCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantCategory_Restaurant_RestaurantId",
                table: "RestaurantCategory",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffRestaurant_Restaurant",
                table: "StaffRestaurant",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffRestaurant_Staff",
                table: "StaffRestaurant",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiningTables_Restaurant_RestaurantId",
                table: "DiningTables");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuCategory_Categories_CategoryId",
                table: "MenuCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuCategory_Menus_MenuId",
                table: "MenuCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuProduct_Menus_MenuId",
                table: "MenuProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuProduct_Products_ProductId",
                table: "MenuProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRestaurant_Products_ProductId",
                table: "ProductRestaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRestaurant_Restaurants_RestaurantId",
                table: "ProductRestaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_DiningTables_DiningTableId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Restaurant_RestaurantId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCategory_Categories_CategoryId",
                table: "RestaurantCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCategory_Restaurant_RestaurantId",
                table: "RestaurantCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffRestaurant_Restaurant",
                table: "StaffRestaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffRestaurant_Staff",
                table: "StaffRestaurant");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RestaurantId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_DiningTables_Restaurant_RestaurantId",
                table: "DiningTables",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuCategory_Categories_CategoryId",
                table: "MenuCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuCategory_Menus_MenuId",
                table: "MenuCategory",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuProduct_Menus_MenuId",
                table: "MenuProduct",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuProduct_Products_ProductId",
                table: "MenuProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRestaurant_Products_ProductId",
                table: "ProductRestaurant",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRestaurant_Restaurants_RestaurantId",
                table: "ProductRestaurant",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_DiningTables_DiningTableId",
                table: "Reservations",
                column: "DiningTableId",
                principalTable: "DiningTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantCategory_Categories_CategoryId",
                table: "RestaurantCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantCategory_Restaurant_RestaurantId",
                table: "RestaurantCategory",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffRestaurant_Restaurant",
                table: "StaffRestaurant",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffRestaurant_Staff",
                table: "StaffRestaurant",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
