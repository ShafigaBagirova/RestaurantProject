using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniApp.Migrations
{
    /// <inheritdoc />
    public partial class AddingRestaurantDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId1",
                table: "RestaurantDetail",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantDetail_RestaurantId1",
                table: "RestaurantDetail",
                column: "RestaurantId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantDetail_Restaurant_RestaurantId1",
                table: "RestaurantDetail",
                column: "RestaurantId1",
                principalTable: "Restaurant",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantDetail_Restaurant_RestaurantId1",
                table: "RestaurantDetail");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantDetail_RestaurantId1",
                table: "RestaurantDetail");

            migrationBuilder.DropColumn(
                name: "RestaurantId1",
                table: "RestaurantDetail");
        }
    }
}
