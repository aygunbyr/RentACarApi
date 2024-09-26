using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentACarApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fuels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transmissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    FuelId = table.Column<int>(type: "int", nullable: false),
                    TransmissionId = table.Column<int>(type: "int", nullable: false),
                    CarState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiloMeter = table.Column<int>(type: "int", nullable: true),
                    ModelYear = table.Column<short>(type: "smallint", nullable: true),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DailyPrice = table.Column<double>(type: "float", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Fuels_FuelId",
                        column: x => x.FuelId,
                        principalTable: "Fuels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Transmissions_TransmissionId",
                        column: x => x.TransmissionId,
                        principalTable: "Transmissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(250), "Red" },
                    { 2, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(272), "Blue" },
                    { 3, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(274), "Green" },
                    { 4, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(276), "Black" },
                    { 5, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(278), "White" },
                    { 6, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(280), "Gray" },
                    { 7, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(282), "Yellow" },
                    { 8, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(285), "Orange" },
                    { 9, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(286), "Purple" }
                });

            migrationBuilder.InsertData(
                table: "Fuels",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(2193), "Gasoline" },
                    { 2, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(2199), "Diesel" },
                    { 3, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(2201), "Electricity" }
                });

            migrationBuilder.InsertData(
                table: "Transmissions",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(3600), "Automatic" },
                    { 2, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(3605), "Manual" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandName", "CarState", "ColorId", "CreatedAt", "DailyPrice", "FuelId", "KiloMeter", "ModelName", "ModelYear", "Plate", "TransmissionId" },
                values: new object[,]
                {
                    { 1L, "Mercedes Benz", "Available", 1, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(5497), 500.0, 3, 15000, "EQC", (short)2016, "34 AB 1456", 1 },
                    { 2L, "Mercedes Benz", "Available", 2, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(5515), 1000.0, 3, 30000, "EQS", (short)2018, "34 BR 8482", 1 },
                    { 3L, "Mercedes Benz", "Available", 3, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(5520), 1500.0, 3, 40000, "EQA", (short)2019, "34 MA 3341", 1 },
                    { 4L, "Mercedes Benz", "On Rent", 4, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(5524), 1200.0, 3, 20000, "EQS SUV", (short)2022, "41 V 1756", 1 },
                    { 5L, "Mercedes Benz", "On Rent", 5, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(5527), 800.0, 1, 22000, "CLA", (short)2024, "41 AB 8601", 2 },
                    { 6L, "Mercedes Benz", "Available", 6, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(5531), 900.0, 1, 14000, "E-Class", (short)2018, "41 AN 2016", 2 },
                    { 7L, "BMW", "Available", 7, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(5535), 750.0, 2, 55000, "X5", (short)2019, "16 DE 2856", 1 },
                    { 8L, "BMW", "Available", 8, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(5538), 900.0, 2, 35000, "X7", (short)2016, "16 TU 2230", 1 },
                    { 9L, "Audi", "In Care", 9, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(5542), 1300.0, 1, 60000, "A8", (short)2018, "35 MN 4546", 1 },
                    { 10L, "Audi", "In Care", 1, new DateTime(2024, 9, 26, 22, 9, 31, 370, DateTimeKind.Local).AddTicks(5546), 1500.0, 1, 75000, "Q7", (short)2020, "35 YU 9402", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ColorId",
                table: "Cars",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FuelId",
                table: "Cars",
                column: "FuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TransmissionId",
                table: "Cars",
                column: "TransmissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Fuels");

            migrationBuilder.DropTable(
                name: "Transmissions");
        }
    }
}
