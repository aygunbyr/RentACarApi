using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentACarApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCarInformationToDatabase : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
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
                    DailyPrice = table.Column<double>(type: "float", nullable: true)
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
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Red" },
                    { 2, "Blue" },
                    { 3, "Green" },
                    { 4, "Black" },
                    { 5, "White" },
                    { 6, "Gray" },
                    { 7, "Yellow" },
                    { 8, "Orange" },
                    { 9, "Purple" }
                });

            migrationBuilder.InsertData(
                table: "Fuels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Gasoline" },
                    { 2, "Diesel" },
                    { 3, "Electricity" }
                });

            migrationBuilder.InsertData(
                table: "Transmissions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Automatic" },
                    { 2, "Manual" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandName", "CarState", "ColorId", "DailyPrice", "FuelId", "KiloMeter", "ModelName", "ModelYear", "Plate", "TransmissionId" },
                values: new object[,]
                {
                    { 1, "Mercedes Benz", "Available", 1, 500.0, 3, 15000, "EQC", null, "34 AB 1456", 1 },
                    { 2, "Mercedes Benz", "Available", 1, 1000.0, 3, 30000, "EQS", null, "34 BR 8482", 1 },
                    { 3, "Mercedes Benz", "Available", 1, 1500.0, 3, 40000, "EQA", null, "34 MA 3341", 1 },
                    { 4, "Mercedes Benz", "On Rent", 1, 1200.0, 3, 20000, "EQS SUV", null, "41 V 1756", 1 },
                    { 5, "Mercedes Benz", "On Rent", 1, 800.0, 1, 22000, "CLA", null, "41 AB 8601", 2 },
                    { 6, "Mercedes Benz", "Available", 1, 900.0, 1, 14000, "E-Class", null, "41 AN 2016", 2 },
                    { 7, "BMW", "Available", 1, 750.0, 2, 55000, "X5", null, "16 DE 2856", 1 },
                    { 8, "BMW", "Available", 1, 900.0, 2, 35000, "X7", null, "16 TU 2230", 1 },
                    { 9, "Audi", "In Care", 1, 1300.0, 1, 60000, "A8", null, "35 MN 4546", 1 },
                    { 10, "Audi", "In Care", 1, 1500.0, 1, 75000, "Q7", null, "35 YU 9402", 1 }
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
