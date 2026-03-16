using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestPractice.Migrations
{
    /// <inheritdoc />
    public partial class componentBases2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentBases");

            migrationBuilder.CreateTable(
                name: "ExtendedComponents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    test1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    test2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    test3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtendedComponents", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtendedComponents");

            migrationBuilder.CreateTable(
                name: "ComponentBases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    test1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    test2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    test3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentBases", x => x.Id);
                });
        }
    }
}
