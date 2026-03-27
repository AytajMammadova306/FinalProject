using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinemastic.Persistance.Contexts.Migrations
{
    /// <inheritdoc />
    public partial class PublicIdForVideosOfMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoPublicId",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoPublicId",
                table: "Movies");
        }
    }
}
