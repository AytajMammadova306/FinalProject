using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinemastic.Persistance.Contexts.Migrations
{
    /// <inheritdoc />
    public partial class SmallAdditionsToGenresAndFranchises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Franchises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Franchises");
        }
    }
}
