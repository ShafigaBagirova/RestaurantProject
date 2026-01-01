using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniApp.Migrations
{
    /// <inheritdoc />
    public partial class CreatedDiningTableConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "DiningTable",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DiningTable_RestaurantId",
                table: "DiningTable",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiningTable_Restaurant_RestaurantId",
                table: "DiningTable",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiningTable_Restaurant_RestaurantId",
                table: "DiningTable");

            migrationBuilder.DropIndex(
                name: "IX_DiningTable_RestaurantId",
                table: "DiningTable");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "DiningTable");
        }
    }
}
