using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CafeEmpApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class APIMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cafes",
                columns: table => new
                {
                    CafeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cafes", x => x.CafeId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email_address = table.Column<string>(type: "TEXT", nullable: false),
                    Phone_number = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cafes",
                columns: new[] { "CafeId", "Description", "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Cafe Desc 1", new Guid("00000000-0000-0000-0000-000000000000"), "Cafe Location 1", "Cafe Name 1" },
                    { 2, "Cafe Desc 2", new Guid("00000000-0000-0000-0000-000000000000"), "Cafe Location 2", "Cafe Name 2" },
                    { 3, "Cafe Desc 3", new Guid("00000000-0000-0000-0000-000000000000"), "Cafe Location 3", "Cafe Name 3" },
                    { 4, "Cafe Desc 4", new Guid("00000000-0000-0000-0000-000000000000"), "Cafe Location 4", "Cafe Name 4" },
                    { 5, "Cafe Desc 5", new Guid("00000000-0000-0000-0000-000000000000"), "Cafe Location 5", "Cafe Name 5" },
                    { 6, "Cafe Desc 6", new Guid("00000000-0000-0000-0000-000000000000"), "Cafe Location 6", "Cafe Name 6" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email_address", "Gender", "Name", "Phone_number" },
                values: new object[,]
                {
                    { 1, "Emp Email 1", "Gender 1", "Emp Name 1", "Emp Phone 1" },
                    { 2, "Emp Email 2", "Gender 2", "Emp Name 2", "Emp Phone 2" },
                    { 3, "Emp Email 3", "Gender 3", "Emp Name 3", "Emp Phone 3" },
                    { 4, "Emp Email 4", "Gender 4", "Emp Name 4", "Emp Phone 4" },
                    { 5, "Emp Email 5", "Gender 5", "Emp Name 5", "Emp Phone 5" },
                    { 6, "Emp Email 6", "Gender 6", "Emp Name 6", "Emp Phone 6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cafes");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
