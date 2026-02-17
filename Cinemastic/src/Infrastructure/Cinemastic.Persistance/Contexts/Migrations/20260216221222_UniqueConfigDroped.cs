using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinemastic.Persistance.Contexts.Migrations
{
    /// <inheritdoc />
    public partial class UniqueConfigDroped : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Crews_Name",
                table: "Crews");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Crews_Name",
                table: "Crews",
                column: "Name",
                unique: true);
        }
    }
}
