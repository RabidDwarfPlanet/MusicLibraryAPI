using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicLibraryAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Album", "Artist", "Genre", "Likes", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "x Infinity", "Watsky", "Rap", 33000, new DateTime(2016, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Talking to Myself" },
                    { 2, null, "The Living Tombstone", "Electronic", 155000, new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hit The Snooze" },
                    { 3, "Dogma Resistance", "RIOT", "Electronic", 248000, new DateTime(2018, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Overkill" },
                    { 4, "Blackmagik Blazing", "Camellia", "Electronic", 10000, new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "SECRET BOSS" },
                    { 5, null, "ELEPS", "Electronic", 1600, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vainilla" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
