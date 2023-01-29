using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SharedTrip.Data.Migrations
{
    public partial class UserTripTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    StartPoint = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EndPoint = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Searts = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripUser",
                columns: table => new
                {
                    UserTripsId = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    UserTripsId1 = table.Column<string>(type: "nvarchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripUser", x => new { x.UserTripsId, x.UserTripsId1 });
                    table.ForeignKey(
                        name: "FK_TripUser_Trip_UserTripsId",
                        column: x => x.UserTripsId,
                        principalTable: "Trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripUser_Users_UserTripsId1",
                        column: x => x.UserTripsId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TripUser_UserTripsId1",
                table: "TripUser",
                column: "UserTripsId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripUser");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
