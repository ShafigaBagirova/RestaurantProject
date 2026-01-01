using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniApp.Migrations
{
    /// <inheritdoc />
    public partial class CreatedChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Menus_MenuId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Menus_RestaurantId",
                table: "Restaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantDetail_Restaurant_RestaurantId1",
                table: "RestaurantDetail");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantDetail_RestaurantId1",
                table: "RestaurantDetail");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_RestaurantId",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Products_MenuId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RestaurantId1",
                table: "RestaurantDetail");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Restaurant",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "MenuProduct",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuProduct", x => new { x.MenuId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_MenuProduct_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_MenuId",
                table: "Restaurant",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuProduct_ProductId",
                table: "MenuProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Menus_MenuId",
                table: "Restaurant",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Menus_MenuId",
                table: "Restaurant");

            migrationBuilder.DropTable(
                name: "MenuProduct");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_MenuId",
                table: "Restaurant");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId1",
                table: "RestaurantDetail",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Restaurant",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Restaurant",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantDetail_RestaurantId1",
                table: "RestaurantDetail",
                column: "RestaurantId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_RestaurantId",
                table: "Restaurant",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MenuId",
                table: "Products",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Menus_MenuId",
                table: "Products",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Menus_RestaurantId",
                table: "Restaurant",
                column: "RestaurantId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantDetail_Restaurant_RestaurantId1",
                table: "RestaurantDetail",
                column: "RestaurantId1",
                principalTable: "Restaurant",
                principalColumn: "Id");
        }
    }
}
