using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIEmployee.Data.Migrations
{
    public partial class SeedDataInitialMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departements",
                columns: table => new
                {
                    DepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.DepId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBrith = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_Employees_Departements_DepId",
                        column: x => x.DepId,
                        principalTable: "Departements",
                        principalColumn: "DepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departements",
                columns: new[] { "DepId", "DepName" },
                values: new object[,]
                {
                    { 1, "Informatique" },
                    { 2, "Mathematique" },
                    { 3, "Biologie" },
                    { 4, "Geologie" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmpId", "DateOfBrith", "DepId", "Email", "FirstName", "LastName", "PhotoPath" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "David@pragimtech.com", "John", "Hastings", "images/john.png" },
                    { 2, new DateTime(1981, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sam@pragimtech.com", "Sam", "Galloway", "images/sam.jpg" },
                    { 3, new DateTime(1979, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "mary@pragimtech.com", "Mary", "Smith", "images/mary.png" },
                    { 4, new DateTime(1982, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "sara@pragimtech.com", "Sara", "Longway", "images/sara.png" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepId",
                table: "Employees",
                column: "DepId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departements");
        }
    }
}
