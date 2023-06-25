using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GW.Api.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MusicModel",
                columns: table => new
                {
                    MusicId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MusicName = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    AuthorName = table.Column<string>(type: "text", nullable: false),
                    AlbumId = table.Column<int>(type: "integer", nullable: false),
                    TrackLink = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false),
                    PlayListModelPlayListId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicModel", x => x.MusicId);
                });

            migrationBuilder.CreateTable(
                name: "PlayListModel",
                columns: table => new
                {
                    PlayListId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    IsFavorite = table.Column<bool>(type: "boolean", nullable: false),
                    UserModelUserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayListModel", x => x.PlayListId);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    PlayListFavoritaPlayListId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserModel_PlayListModel_PlayListFavoritaPlayListId",
                        column: x => x.PlayListFavoritaPlayListId,
                        principalTable: "PlayListModel",
                        principalColumn: "PlayListId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicModel_PlayListModelPlayListId",
                table: "MusicModel",
                column: "PlayListModelPlayListId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayListModel_UserModelUserId",
                table: "PlayListModel",
                column: "UserModelUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_PlayListFavoritaPlayListId",
                table: "UserModel",
                column: "PlayListFavoritaPlayListId");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicModel_PlayListModel_PlayListModelPlayListId",
                table: "MusicModel",
                column: "PlayListModelPlayListId",
                principalTable: "PlayListModel",
                principalColumn: "PlayListId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayListModel_UserModel_UserModelUserId",
                table: "PlayListModel",
                column: "UserModelUserId",
                principalTable: "UserModel",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserModel_PlayListModel_PlayListFavoritaPlayListId",
                table: "UserModel");

            migrationBuilder.DropTable(
                name: "MusicModel");

            migrationBuilder.DropTable(
                name: "PlayListModel");

            migrationBuilder.DropTable(
                name: "UserModel");
        }
    }
}
