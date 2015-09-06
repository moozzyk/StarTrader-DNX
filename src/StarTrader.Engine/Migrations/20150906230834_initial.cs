using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.SqlServer.Metadata;

namespace StarTrader.Engine.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Universe",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universe", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    Created = table.Column<DateTimeOffset>(isNullable: false),
                    Name = table.Column<string>(isNullable: true),
                    OwnerId = table.Column<int>(isNullable: false),
                    Status = table.Column<int>(isNullable: false),
                    Turn = table.Column<int>(isNullable: false),
                    UniverseId = table.Column<int>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Universe_UniverseId",
                        column: x => x.UniverseId,
                        principalTable: "Universe",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "StarSystem",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    HasSafeBerth = table.Column<bool>(isNullable: false),
                    HasShipyard = table.Column<bool>(isNullable: false),
                    LawLevel = table.Column<int>(isNullable: false),
                    Name = table.Column<string>(isNullable: true),
                    PatrolRating = table.Column<int>(isNullable: false),
                    SecurityRating = table.Column<int>(isNullable: false),
                    SpacePortClass = table.Column<int>(isNullable: false),
                    UniverseId = table.Column<int>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarSystem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StarSystem_Universe_UniverseId",
                        column: x => x.UniverseId,
                        principalTable: "Universe",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    GameId = table.Column<int>(isNullable: true),
                    Name = table.Column<string>(isNullable: true),
                    OwnerId = table.Column<int>(isNullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Player");
            migrationBuilder.DropTable("StarSystem");
            migrationBuilder.DropTable("Game");
            migrationBuilder.DropTable("Universe");
        }
    }
}
