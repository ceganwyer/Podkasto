using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Podkasto.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Feeds",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    URL = table.Column<string>(type: "TEXT", nullable: false),
                    FeedType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feeds", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FeedCategory",
                columns: table => new
                {
                    FeedID = table.Column<Guid>(type: "TEXT", nullable: false),
                    CategoryID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedCategory", x => new { x.FeedID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_FeedCategory_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedCategory_Feeds_FeedID",
                        column: x => x.FeedID,
                        principalTable: "Feeds",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Podcast",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PodcastTitle = table.Column<string>(type: "TEXT", nullable: false),
                    CustomTitle = table.Column<string>(type: "TEXT", nullable: true),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    URL = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Language = table.Column<string>(type: "TEXT", nullable: false),
                    ImageURL = table.Column<string>(type: "TEXT", nullable: true),
                    FeedID = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podcast", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Podcast_Feeds_FeedID",
                        column: x => x.FeedID,
                        principalTable: "Feeds",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Episode",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Explicit = table.Column<string>(type: "TEXT", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "TEXT", nullable: true),
                    EpisodeURL = table.Column<string>(type: "TEXT", nullable: false),
                    MediaURI = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<int>(type: "INTEGER", nullable: false),
                    PodcastID = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episode", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Episode_Podcast_PodcastID",
                        column: x => x.PodcastID,
                        principalTable: "Podcast",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Genre" },
                values: new object[] { new Guid("fb866ceb-63ed-4b11-825b-201a61c89c47"), "Comedy" });

            migrationBuilder.InsertData(
                table: "Feeds",
                columns: new[] { "ID", "FeedType", "URL" },
                values: new object[] { new Guid("9d41d750-3907-4adf-9095-1d6f17a5d254"), 0, "http://feeds.codenewbie.org/cnpodcast.xml" });

            migrationBuilder.InsertData(
                table: "FeedCategory",
                columns: new[] { "CategoryID", "FeedID" },
                values: new object[] { new Guid("fb866ceb-63ed-4b11-825b-201a61c89c47"), new Guid("9d41d750-3907-4adf-9095-1d6f17a5d254") });

            migrationBuilder.CreateIndex(
                name: "IX_Episode_PodcastID",
                table: "Episode",
                column: "PodcastID");

            migrationBuilder.CreateIndex(
                name: "IX_FeedCategory_CategoryID",
                table: "FeedCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Podcast_FeedID",
                table: "Podcast",
                column: "FeedID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Episode");

            migrationBuilder.DropTable(
                name: "FeedCategory");

            migrationBuilder.DropTable(
                name: "Podcast");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Feeds");
        }
    }
}
