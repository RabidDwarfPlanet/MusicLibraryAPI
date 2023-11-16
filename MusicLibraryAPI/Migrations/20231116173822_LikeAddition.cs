using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicLibraryAPI.Migrations
{
    /// <inheritdoc />
    public partial class LikeAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Songs");
        }
    }
}
