using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MiniApp.Migrations
{
    /// <inheritdoc />
    public partial class CreatedProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCategory_Categories_CategoriesId",
                table: "RestaurantCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCategory_Restaurant_RestaurantsId",
                table: "RestaurantCategory");

            migrationBuilder.RenameColumn(
                name: "RestaurantsId",
                table: "RestaurantCategory",
                newName: "RestaurantId");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "RestaurantCategory",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantCategory_RestaurantsId",
                table: "RestaurantCategory",
                newName: "IX_RestaurantCategory_RestaurantId");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductRestaurant",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRestaurant", x => new { x.ProductId, x.RestaurantId });
                    table.ForeignKey(
                        name: "FK_ProductRestaurant_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductRestaurant_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductRestaurant_RestaurantId",
                table: "ProductRestaurant",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCategory_Categories_CategoryId",
                table: "RestaurantCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCategory_Restaurant_RestaurantId",
                table: "RestaurantCategory");

            migrationBuilder.DropTable(
                name: "ProductRestaurant");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Name",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "RestaurantCategory",
                newName: "RestaurantsId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "RestaurantCategory",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantCategory_RestaurantId",
                table: "RestaurantCategory",
                newName: "IX_RestaurantCategory_RestaurantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantCategory_Categories_CategoriesId",
                table: "RestaurantCategory",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantCategory_Restaurant_RestaurantsId",
                table: "RestaurantCategory",
                column: "RestaurantsId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
