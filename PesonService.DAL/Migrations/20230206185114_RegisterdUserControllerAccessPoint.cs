using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PesonService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RegisterdUserControllerAccessPoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccessPoints",
                columns: new[] { "Id", "ControllerName", "CreatedAt", "ModifiedAt" },
                values: new object[] { new Guid("9efb089e-b4d8-4a15-9000-485acbc7848c"), "UserController", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccessPoints",
                keyColumn: "Id",
                keyValue: new Guid("9efb089e-b4d8-4a15-9000-485acbc7848c"));
        }
    }
}
