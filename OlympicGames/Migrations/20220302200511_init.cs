using Microsoft.EntityFrameworkCore.Migrations;

namespace OlympicGames.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FlagImage = table.Column<string>(nullable: true),
                    SportId = table.Column<string>(nullable: true),
                    GameId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                    table.ForeignKey(
                        name: "FK_Countries_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "Name" },
                values: new object[,]
                {
                    { "wo", "Winter Olympics" },
                    { "so", "Summer Olympics" },
                    { "pa", "Paralympics" },
                    { "yo", "Youth Olympics" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "Name" },
                values: new object[,]
                {
                    { "curl", "Curling" },
                    { "bob", "Bobsleigh" },
                    { "dive", "Diving" },
                    { "rc", "Road Cycling" },
                    { "arch", "Archery" },
                    { "cs", "Canoe Spring" },
                    { "bd", "Break Dancing" },
                    { "sb", "Skateboarding" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "FlagImage", "GameId", "Name", "SportId" },
                values: new object[,]
                {
                    { "ca", "ca.png", "wo", "Canada", "curl" },
                    { "fi", "fi.png", "yo", "Finland", "sb" },
                    { "ru", "ru.png", "yo", "Russia", "bd" },
                    { "cy", "cy.png", "yo", "Cyprus", "bd" },
                    { "fr", "fr.png", "yo", "France", "bd" },
                    { "zw", "zw.png", "pa", "Zimbabwe", "cs" },
                    { "pk", "pk.png", "pa", "Pakistan", "cs" },
                    { "austria", "austria.png", "pa", "Austria", "cs" },
                    { "ua", "ua.png", "pa", "Ukraine", "arch" },
                    { "uy", "uy.png", "pa", "Uruguay", "arch" },
                    { "th", "th.png", "pa", "Thailand", "arch" },
                    { "us", "us.png", "so", "USA", "rc" },
                    { "bl", "nl.png", "so", "Netherlands", "rc" },
                    { "br", "br.png", "so", "Brazil", "rc" },
                    { "mx", "mx.png", "so", "Mexico", "dive" },
                    { "china", "china.png", "so", "China", "dive" },
                    { "germany", "germany.png", "so", "Germany", "dive" },
                    { "jp", "jp.png", "wo", "Japan", "bob" },
                    { "it", "it.png", "wo", "Italy", "bob" },
                    { "jm", "jm.png", "wo", "Jamaica", "bob" },
                    { "gb", "gb.png", "wo", "Great Britain", "curl" },
                    { "se", "se.png", "wo", "Sweden", "curl" },
                    { "sk", "sk.png", "yo", "Slovakia", "sb" },
                    { "pt", "pt.png", "yo", "Portugal", "sb" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GameId",
                table: "Countries",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_SportId",
                table: "Countries",
                column: "SportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
