using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinemastic.Persistance.Contexts.Migrations
{
    /// <inheritdoc />
    public partial class PublicIdForImagesOfMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverPublicId",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePublicId",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverPublicId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ImagePublicId",
                table: "Movies");
        }
    }
}
