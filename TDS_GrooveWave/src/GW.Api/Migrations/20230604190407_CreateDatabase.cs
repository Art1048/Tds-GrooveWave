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
                name: "ServiceModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MusicId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    TrackLink = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicModelPlayListModel",
                columns: table => new
                {
                    MusicsId = table.Column<int>(type: "integer", nullable: false),
                    PlaylistsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicModelPlayListModel", x => new { x.MusicsId, x.PlaylistsId });
                    table.ForeignKey(
                        name: "FK_MusicModelPlayListModel_ServiceModel_MusicsId",
                        column: x => x.MusicsId,
                        principalTable: "ServiceModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableModel",
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
                    table.PrimaryKey("PK_TableModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    PlayListFavoritaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserModel_TableModel_PlayListFavoritaId",
                        column: x => x.PlayListFavoritaId,
                        principalTable: "TableModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicModelPlayListModel_PlaylistsId",
                table: "MusicModelPlayListModel",
                column: "PlaylistsId");

            migrationBuilder.CreateIndex(
                name: "IX_TableModel_UserModelId",
                table: "TableModel",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_PlayListFavoritaId",
                table: "UserModel",
                column: "PlayListFavoritaId");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicModelPlayListModel_TableModel_PlaylistsId",
                table: "MusicModelPlayListModel",
                column: "PlaylistsId",
                principalTable: "TableModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TableModel_UserModel_UserModelId",
                table: "TableModel",
                column: "UserModelId",
                principalTable: "UserModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserModel_TableModel_PlayListFavoritaId",
                table: "UserModel");

            migrationBuilder.DropTable(
                name: "MusicModelPlayListModel");

            migrationBuilder.DropTable(
                name: "ServiceModel");

            migrationBuilder.DropTable(
                name: "TableModel");

            migrationBuilder.DropTable(
                name: "UserModel");
        }
    }
}
