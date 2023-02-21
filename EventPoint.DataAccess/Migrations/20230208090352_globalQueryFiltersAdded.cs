using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPoint.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class globalQueryFiltersAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EventDate", "IsDeleted" },
                values: new object[] { new DateTime(2023, 2, 8, 12, 3, 52, 777, DateTimeKind.Local).AddTicks(2756), new DateTime(2023, 2, 18, 12, 3, 52, 777, DateTimeKind.Local).AddTicks(2738), false });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EventDate", "IsDeleted" },
                values: new object[] { new DateTime(2023, 2, 8, 12, 3, 52, 777, DateTimeKind.Local).AddTicks(2761), new DateTime(2023, 2, 11, 12, 3, 52, 777, DateTimeKind.Local).AddTicks(2760), false });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EventDate", "IsDeleted" },
                values: new object[] { new DateTime(2023, 2, 8, 12, 3, 52, 777, DateTimeKind.Local).AddTicks(2763), new DateTime(2023, 3, 5, 12, 3, 52, 777, DateTimeKind.Local).AddTicks(2762), false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

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
    }
}
