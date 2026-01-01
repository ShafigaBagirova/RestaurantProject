using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniApp.Migrations
{
    /// <inheritdoc />
    public partial class CreatedReservationConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiningTableId",
                table: "Reservation",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_DiningTableId",
                table: "Reservation",
                column: "DiningTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_DiningTable_DiningTableId",
                table: "Reservation",
                column: "DiningTableId",
                principalTable: "DiningTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_DiningTable_DiningTableId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_DiningTableId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "DiningTableId",
                table: "Reservation");
        }
    }
}
