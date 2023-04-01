using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarrierConfigurations",
                columns: table => new
                {
                    CarrierConfigurationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierId = table.Column<int>(type: "int", nullable: false),
                    CarrierMaxDesi = table.Column<int>(type: "int", nullable: false),
                    CarrierMinDesi = table.Column<int>(type: "int", nullable: false),
                    CarrierCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrierConfigurations", x => x.CarrierConfigurationId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierId = table.Column<int>(type: "int", nullable: false),
                    OrderDesi = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false),
                    OrderCarrierCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Carriers",
                columns: table => new
                {
                    CarrierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CarrierIsActive = table.Column<bool>(type: "bit", nullable: false),
                    CarrierPlusDesiCost = table.Column<int>(type: "int", nullable: false),
                    CarrierConfigurationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.CarrierId);
                    table.ForeignKey(
                        name: "FK_Carriers_CarrierConfigurations_CarrierConfigurationId",
                        column: x => x.CarrierConfigurationId,
                        principalTable: "CarrierConfigurations",
                        principalColumn: "CarrierConfigurationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CarrierConfigurations",
                columns: new[] { "CarrierConfigurationId", "CarrierCost", "CarrierId", "CarrierMaxDesi", "CarrierMinDesi" },
                values: new object[] { 1, 40.00m, 1, 20, 2 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CarrierId", "OrderCarrierCost", "OrderDate", "OrderDesi" },
                values: new object[] { 1, 1, 50.00m, new DateTime(2023, 3, 31, 13, 48, 49, 745, DateTimeKind.Local).AddTicks(1965), 10 });

            migrationBuilder.InsertData(
                table: "Carriers",
                columns: new[] { "CarrierId", "CarrierConfigurationId", "CarrierIsActive", "CarrierName", "CarrierPlusDesiCost" },
                values: new object[] { 1, 1, true, "Aras", 10 });

            migrationBuilder.CreateIndex(
                name: "IX_Carriers_CarrierConfigurationId",
                table: "Carriers",
                column: "CarrierConfigurationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carriers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "CarrierConfigurations");
        }
    }
}
