using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PesonService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedAccessPointsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessPoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessPoints", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AccessPoints",
                columns: new[] { "Id", "ControllerName" },
                values: new object[,]
                {
                    { new Guid("01e31986-e9e4-4507-9a52-02aa4ffa2079"), "PersonController" },
                    { new Guid("c8280d0c-fbba-4167-baf8-3250fcc14aa6"), "SecurityController" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessPoints");
        }
    }
}
