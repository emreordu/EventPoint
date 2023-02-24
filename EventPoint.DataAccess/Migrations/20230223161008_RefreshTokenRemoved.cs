using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventPoint.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RefreshTokenRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRefreshTokens");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRefreshTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshTokens", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedDate", "Description", "EventDate", "IsDeleted", "Name", "ParticipantLimit", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 8, 12, 3, 52, 777, DateTimeKind.Local).AddTicks(2756), "descriptions will be added", new DateTime(2023, 2, 18, 12, 3, 52, 777, DateTimeKind.Local).AddTicks(2738), false, "International WebSummIT", 100, null },
                    { 2, new DateTime(2023, 2, 8, 12, 3, 52, 777, DateTimeKind.Local).AddTicks(2761), "descriptions will be added", new DateTime(2023, 2, 11, 12, 3, 52, 777, DateTimeKind.Local).AddTicks(2760), false, "Speaking Club Event", 25, null },
                    { 3, new DateTime(2023, 2, 8, 12, 3, 52, 777, DateTimeKind.Local).AddTicks(2763), "descriptions will be added", new DateTime(2023, 3, 5, 12, 3, 52, 777, DateTimeKind.Local).AddTicks(2762), false, "İstanbul Shopping Fest", 3000, null }
                });
        }
    }
}
