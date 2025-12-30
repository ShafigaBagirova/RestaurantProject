using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniApp.Migrations
{
    /// <inheritdoc />
    public partial class RenemaeColumnRestaurantId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantDetail_Restaurant_RestauranId",
                table: "RestaurantDetail");

            migrationBuilder.RenameColumn(
                name: "RestauranId",
                table: "RestaurantDetail",
                newName: "RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantDetail_RestauranId",
                table: "RestaurantDetail",
                newName: "IX_RestaurantDetail_RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantDetail_Restaurant_RestaurantId",
                table: "RestaurantDetail",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantDetail_Restaurant_RestaurantId",
                table: "RestaurantDetail");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "RestaurantDetail",
                newName: "RestauranId");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantDetail_RestaurantId",
                table: "RestaurantDetail",
                newName: "IX_RestaurantDetail_RestauranId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantDetail_Restaurant_RestauranId",
                table: "RestaurantDetail",
                column: "RestauranId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
