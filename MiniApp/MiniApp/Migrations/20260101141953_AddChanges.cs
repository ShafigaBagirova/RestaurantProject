using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniApp.Migrations
{
    /// <inheritdoc />
    public partial class AddChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiningTable_Restaurant_RestaurantId",
                table: "DiningTable");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_DiningTable_DiningTableId",
                table: "Reservation");

            migrationBuilder.DropTable(
                name: "RestaurantStaff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiningTable",
                table: "DiningTable");

            migrationBuilder.RenameTable(
                name: "Staffs",
                newName: "Staff");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameTable(
                name: "DiningTable",
                newName: "DiningTables");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_DiningTableId",
                table: "Reservations",
                newName: "IX_Reservations_DiningTableId");

            migrationBuilder.RenameIndex(
                name: "IX_DiningTable_RestaurantId",
                table: "DiningTables",
                newName: "IX_DiningTables_RestaurantId");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Staff",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Staff",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Staff",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Staff",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerPhone",
                table: "Reservations",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                table: "Reservations",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "DiningTables",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staff",
                table: "Staff",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiningTables",
                table: "DiningTables",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StaffRestaurant",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "integer", nullable: false),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffRestaurant", x => new { x.StaffId, x.RestaurantId });
                    table.ForeignKey(
                        name: "FK_StaffRestaurant_Restaurant",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffRestaurant_Staff",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantDetail_Address",
                table: "RestaurantDetail",
                column: "Address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_Phone",
                table: "Restaurant",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Email",
                table: "Staff",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Phone",
                table: "Staff",
                column: "Phone",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Staff_Age",
                table: "Staff",
                sql: "\"Age\" >= 18");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerPhone",
                table: "Reservations",
                column: "CustomerPhone",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_ReservationDate_Future",
                table: "Reservations",
                sql: "\"ReservationDate\" >= CURRENT_TIMESTAMP");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Reservations_GuestCount",
                table: "Reservations",
                sql: "\"GuestCount\" > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_DiningTable_Capacity",
                table: "DiningTables",
                sql: "\"Capacity\" > 0");

            migrationBuilder.CreateIndex(
                name: "IX_StaffRestaurant_RestaurantId",
                table: "StaffRestaurant",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiningTables_Restaurant_RestaurantId",
                table: "DiningTables",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_DiningTables_DiningTableId",
                table: "Reservations",
                column: "DiningTableId",
                principalTable: "DiningTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiningTables_Restaurant_RestaurantId",
                table: "DiningTables");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_DiningTables_DiningTableId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "StaffRestaurant");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantDetail_Address",
                table: "RestaurantDetail");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_Phone",
                table: "Restaurant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staff",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Staff_Email",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Staff_Phone",
                table: "Staff");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Staff_Age",
                table: "Staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CustomerPhone",
                table: "Reservations");

            migrationBuilder.DropCheckConstraint(
                name: "CK_ReservationDate_Future",
                table: "Reservations");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Reservations_GuestCount",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiningTables",
                table: "DiningTables");

            migrationBuilder.DropCheckConstraint(
                name: "CK_DiningTable_Capacity",
                table: "DiningTables");

            migrationBuilder.RenameTable(
                name: "Staff",
                newName: "Staffs");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameTable(
                name: "DiningTables",
                newName: "DiningTable");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_DiningTableId",
                table: "Reservation",
                newName: "IX_Reservation_DiningTableId");

            migrationBuilder.RenameIndex(
                name: "IX_DiningTables_RestaurantId",
                table: "DiningTable",
                newName: "IX_DiningTable_RestaurantId");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Staffs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Staffs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Staffs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Staffs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerPhone",
                table: "Reservation",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                table: "Reservation",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservation",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "DiningTable",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiningTable",
                table: "DiningTable",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RestaurantStaff",
                columns: table => new
                {
                    RestaurantsId = table.Column<int>(type: "integer", nullable: false),
                    StaffsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantStaff", x => new { x.RestaurantsId, x.StaffsId });
                    table.ForeignKey(
                        name: "FK_RestaurantStaff_Restaurant_RestaurantsId",
                        column: x => x.RestaurantsId,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantStaff_Staffs_StaffsId",
                        column: x => x.StaffsId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantStaff_StaffsId",
                table: "RestaurantStaff",
                column: "StaffsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiningTable_Restaurant_RestaurantId",
                table: "DiningTable",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_DiningTable_DiningTableId",
                table: "Reservation",
                column: "DiningTableId",
                principalTable: "DiningTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
