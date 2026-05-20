using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PCs_Rest_Api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComponentManufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FoundationDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentManufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Computer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Weight = table.Column<double>(type: "float", maxLength: 5, nullable: false),
                    Warranty = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Component",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(10)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentManufacturerId = table.Column<int>(type: "int", nullable: false),
                    ComponentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Component", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Component_ComponentManufacturer_ComponentManufacturerId",
                        column: x => x.ComponentManufacturerId,
                        principalTable: "ComponentManufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Component_ComponentType_ComponentTypeId",
                        column: x => x.ComponentTypeId,
                        principalTable: "ComponentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComputerComponent",
                columns: table => new
                {
                    ComputerId = table.Column<int>(type: "int", nullable: false),
                    ComponentCode = table.Column<string>(type: "char(10)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerComponent", x => new { x.ComputerId, x.ComponentCode });
                    table.ForeignKey(
                        name: "FK_ComputerComponent_Component_ComponentCode",
                        column: x => x.ComponentCode,
                        principalTable: "Component",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComputerComponent_Computer_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ComponentManufacturer",
                columns: new[] { "Id", "Abbreviation", "FoundationDate", "FullName" },
                values: new object[,]
                {
                    { 1, "CRU", new DateOnly(1996, 1, 1), "Crucial Technology" },
                    { 2, "SND", new DateOnly(1938, 3, 1), "Samsung Electronics" },
                    { 3, "NVD", new DateOnly(1938, 4, 5), "NVIDIA Corporation" },
                    { 4, "INT", new DateOnly(1968, 7, 18), "Intel Corporation" }
                });

            migrationBuilder.InsertData(
                table: "ComponentType",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { 1, "RAM", "Memory (RAM)" },
                    { 2, "SSD", "Solid State Drive" },
                    { 3, "GPU", "Graphics Card" },
                    { 4, "CPU", "Central Processing Unit" }
                });

            migrationBuilder.InsertData(
                table: "Computer",
                columns: new[] { "Id", "CreatedAt", "Name", "Stock", "Warranty", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asus TUF Gaming", 10, 1, 2.2000000476837158 },
                    { 2, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dell Alienware", 5, 2, 2.5 },
                    { 3, new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lenovo ThinkPad", 12, 3, 2.7000000476837158 }
                });

            migrationBuilder.InsertData(
                table: "Component",
                columns: new[] { "Code", "ComponentManufacturerId", "ComponentTypeId", "Description", "Name" },
                values: new object[,]
                {
                    { "CPU0000001", 4, 4, "4 Cores 8 Threads 4.20 GHz ", "Intel Core i5" },
                    { "GPU0000001", 3, 3, "4GB VRAM", "RTX 4080 Super" },
                    { "RAM0000001", 1, 1, "8GB DDR4 3200MHz", "Corsair Vengeance" },
                    { "SSD0000001", 2, 2, "500GB NVMe M.2 PCIe Gen3", "Samsung SSD" }
                });

            migrationBuilder.InsertData(
                table: "ComputerComponent",
                columns: new[] { "ComponentCode", "ComputerId", "Amount" },
                values: new object[,]
                {
                    { "CPU0000001", 1, 1 },
                    { "GPU0000001", 1, 1 },
                    { "RAM0000001", 1, 4 },
                    { "SSD0000001", 1, 1 },
                    { "CPU0000001", 2, 1 },
                    { "GPU0000001", 2, 1 },
                    { "RAM0000001", 2, 2 },
                    { "SSD0000001", 2, 1 },
                    { "CPU0000001", 3, 1 },
                    { "GPU0000001", 3, 1 },
                    { "RAM0000001", 3, 4 },
                    { "SSD0000001", 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Component_ComponentManufacturerId",
                table: "Component",
                column: "ComponentManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Component_ComponentTypeId",
                table: "Component",
                column: "ComponentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerComponent_ComponentCode",
                table: "ComputerComponent",
                column: "ComponentCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputerComponent");

            migrationBuilder.DropTable(
                name: "Component");

            migrationBuilder.DropTable(
                name: "Computer");

            migrationBuilder.DropTable(
                name: "ComponentManufacturer");

            migrationBuilder.DropTable(
                name: "ComponentType");
        }
    }
}
