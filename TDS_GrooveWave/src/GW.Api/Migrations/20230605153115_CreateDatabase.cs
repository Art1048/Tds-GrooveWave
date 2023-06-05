using System.Collections.Generic;
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MusicId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    TrackLink = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false),
                    PlaylistsId = table.Column<List<int>>(type: "integer[]", nullable: true),
                    PlayListModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayListModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    IsFavorite = table.Column<bool>(type: "boolean", nullable: false),
                    UserModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayListModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    PlayListFavoritaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserModel_PlayListModel_PlayListFavoritaId",
                        column: x => x.PlayListFavoritaId,
                        principalTable: "PlayListModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicModel_PlayListModelId",
                table: "MusicModel",
                column: "PlayListModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayListModel_UserModelId",
                table: "PlayListModel",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_PlayListFavoritaId",
                table: "UserModel",
                column: "PlayListFavoritaId");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicModel_PlayListModel_PlayListModelId",
                table: "MusicModel",
                column: "PlayListModelId",
                principalTable: "PlayListModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayListModel_UserModel_UserModelId",
                table: "PlayListModel",
                column: "UserModelId",
                principalTable: "UserModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserModel_PlayListModel_PlayListFavoritaId",
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
