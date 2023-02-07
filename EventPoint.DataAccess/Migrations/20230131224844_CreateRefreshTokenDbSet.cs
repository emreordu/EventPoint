using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPoint.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateRefreshTokenDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EventDate" },
                values: new object[] { new DateTime(2023, 2, 1, 1, 48, 44, 107, DateTimeKind.Local).AddTicks(6316), new DateTime(2023, 2, 11, 1, 48, 44, 107, DateTimeKind.Local).AddTicks(6295) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EventDate" },
                values: new object[] { new DateTime(2023, 2, 1, 1, 48, 44, 107, DateTimeKind.Local).AddTicks(6323), new DateTime(2023, 2, 4, 1, 48, 44, 107, DateTimeKind.Local).AddTicks(6322) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EventDate" },
                values: new object[] { new DateTime(2023, 2, 1, 1, 48, 44, 107, DateTimeKind.Local).AddTicks(6325), new DateTime(2023, 2, 26, 1, 48, 44, 107, DateTimeKind.Local).AddTicks(6324) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRefreshTokens");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EventDate" },
                values: new object[] { new DateTime(2023, 1, 28, 1, 56, 4, 890, DateTimeKind.Local).AddTicks(9251), new DateTime(2023, 2, 7, 1, 56, 4, 890, DateTimeKind.Local).AddTicks(9234) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EventDate" },
                values: new object[] { new DateTime(2023, 1, 28, 1, 56, 4, 890, DateTimeKind.Local).AddTicks(9257), new DateTime(2023, 1, 31, 1, 56, 4, 890, DateTimeKind.Local).AddTicks(9257) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EventDate" },
                values: new object[] { new DateTime(2023, 1, 28, 1, 56, 4, 890, DateTimeKind.Local).AddTicks(9260), new DateTime(2023, 2, 22, 1, 56, 4, 890, DateTimeKind.Local).AddTicks(9259) });
        }
    }
}
