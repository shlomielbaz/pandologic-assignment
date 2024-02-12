using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PA.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "jobs",
                columns: new[] { "id", "date", "predicted_views", "total_jobs", "total_views" },
                values: new object[,]
                {
                    { 1L, new DateTime(2014, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3, 0 },
                    { 2L, new DateTime(2014, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 1 },
                    { 3L, new DateTime(2014, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 2 },
                    { 4L, new DateTime(2014, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 11, 5 },
                    { 5L, new DateTime(2014, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, 6 },
                    { 6L, new DateTime(2014, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 6, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 6L);
        }
    }
}
