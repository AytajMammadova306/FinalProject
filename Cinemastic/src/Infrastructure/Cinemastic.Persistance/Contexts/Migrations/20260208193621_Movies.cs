using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinemastic.Persistance.Contexts.Migrations
{
    /// <inheritdoc />
    public partial class Movies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentCasts_Contents_ContentId",
                table: "ContentCasts");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentCrews_Contents_ContentId",
                table: "ContentCrews");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentGenres_Contents_ContentId",
                table: "ContentGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentTags_Contents_ContentId",
                table: "ContentTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contents",
                table: "Contents");

            migrationBuilder.RenameTable(
                name: "Contents",
                newName: "Content");

            migrationBuilder.AddColumn<long>(
                name: "MovieId",
                table: "ContentTags",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MovieId",
                table: "ContentGenres",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MovieId",
                table: "ContentCrews",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MovieId",
                table: "ContentCasts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Content",
                table: "Content",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DurationMinutes = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeRating = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentTags_MovieId",
                table: "ContentTags",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentGenres_MovieId",
                table: "ContentGenres",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentCrews_MovieId",
                table: "ContentCrews",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentCasts_MovieId",
                table: "ContentCasts",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentCasts_Content_ContentId",
                table: "ContentCasts",
                column: "ContentId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentCasts_Movie_MovieId",
                table: "ContentCasts",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentCrews_Content_ContentId",
                table: "ContentCrews",
                column: "ContentId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentCrews_Movie_MovieId",
                table: "ContentCrews",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentGenres_Content_ContentId",
                table: "ContentGenres",
                column: "ContentId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentGenres_Movie_MovieId",
                table: "ContentGenres",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentTags_Content_ContentId",
                table: "ContentTags",
                column: "ContentId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentTags_Movie_MovieId",
                table: "ContentTags",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentCasts_Content_ContentId",
                table: "ContentCasts");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentCasts_Movie_MovieId",
                table: "ContentCasts");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentCrews_Content_ContentId",
                table: "ContentCrews");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentCrews_Movie_MovieId",
                table: "ContentCrews");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentGenres_Content_ContentId",
                table: "ContentGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentGenres_Movie_MovieId",
                table: "ContentGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentTags_Content_ContentId",
                table: "ContentTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentTags_Movie_MovieId",
                table: "ContentTags");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_ContentTags_MovieId",
                table: "ContentTags");

            migrationBuilder.DropIndex(
                name: "IX_ContentGenres_MovieId",
                table: "ContentGenres");

            migrationBuilder.DropIndex(
                name: "IX_ContentCrews_MovieId",
                table: "ContentCrews");

            migrationBuilder.DropIndex(
                name: "IX_ContentCasts_MovieId",
                table: "ContentCasts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Content",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "ContentTags");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "ContentGenres");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "ContentCrews");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "ContentCasts");

            migrationBuilder.RenameTable(
                name: "Content",
                newName: "Contents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contents",
                table: "Contents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentCasts_Contents_ContentId",
                table: "ContentCasts",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentCrews_Contents_ContentId",
                table: "ContentCrews",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentGenres_Contents_ContentId",
                table: "ContentGenres",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentTags_Contents_ContentId",
                table: "ContentTags",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
