using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicLibraryAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Playlist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false),
                    Artist = table.Column<string>(type: "longtext", nullable: false),
                    Album = table.Column<string>(type: "longtext", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Genre = table.Column<string>(type: "longtext", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    PlaylistId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Playlist_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlist",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Playlist",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "EDM" },
                    { 2, "Lyrical" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Album", "Artist", "Genre", "Likes", "PlaylistId", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "x Infinity", "Watsky", "Rap", 33000, null, new DateTime(2016, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Talking to Myself" },
                    { 2, null, "The Living Tombstone", "Electronic", 155000, null, new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hit The Snooze" },
                    { 3, "Dogma Resistance", "RIOT", "Electronic", 248000, null, new DateTime(2018, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Overkill" },
                    { 4, "Blackmagik Blazing", "Camellia", "Electronic", 10000, null, new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "SECRET BOSS" },
                    { 5, null, "ELEPS", "Electronic", 1600, null, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vainilla" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_PlaylistId",
                table: "Songs",
                column: "PlaylistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Playlist");
        }
    }
}
