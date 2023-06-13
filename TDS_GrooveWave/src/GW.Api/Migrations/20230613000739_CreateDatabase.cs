﻿using Microsoft.EntityFrameworkCore.Migrations;

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
                    MusicId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MusicName = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false),
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false),
                    TrackLink = table.Column<string>(type: "TEXT", nullable: false),
                    Photo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicModel", x => x.MusicId);
                });

            migrationBuilder.CreateTable(
                name: "MusicModelPlayListModel",
                columns: table => new
                {
                    MusicsMusicId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlaylistsPlayListId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicModelPlayListModel", x => new { x.MusicsMusicId, x.PlaylistsPlayListId });
                    table.ForeignKey(
                        name: "FK_MusicModelPlayListModel_MusicModel_MusicsMusicId",
                        column: x => x.MusicsMusicId,
                        principalTable: "MusicModel",
                        principalColumn: "MusicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayListModel",
                columns: table => new
                {
                    PlayListId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    IsFavorite = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserModelUserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayListModel", x => x.PlayListId);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    PlayListFavoritaPlayListId = table.Column<int>(type: "INTEGER", nullable: true)
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
                name: "IX_MusicModelPlayListModel_PlaylistsPlayListId",
                table: "MusicModelPlayListModel",
                column: "PlaylistsPlayListId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayListModel_UserModelUserId",
                table: "PlayListModel",
                column: "UserModelUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_PlayListFavoritaPlayListId",
                table: "UserModel",
                column: "PlayListFavoritaPlayListId");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicModelPlayListModel_PlayListModel_PlaylistsPlayListId",
                table: "MusicModelPlayListModel",
                column: "PlaylistsPlayListId",
                principalTable: "PlayListModel",
                principalColumn: "PlayListId",
                onDelete: ReferentialAction.Cascade);

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
                name: "MusicModelPlayListModel");

            migrationBuilder.DropTable(
                name: "MusicModel");

            migrationBuilder.DropTable(
                name: "PlayListModel");

            migrationBuilder.DropTable(
                name: "UserModel");
        }
    }
}
