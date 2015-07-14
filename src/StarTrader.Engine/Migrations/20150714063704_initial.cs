using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace StarTrader.Engine.Migrations
{
    public partial class initial : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateSequence(
                name: "DefaultSequence",
                type: "bigint",
                startWith: 1L,
                incrementBy: 10);
            migration.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    Created = table.Column(type: "datetimeoffset", nullable: false),
                    Name = table.Column(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column(type: "int", nullable: false),
                    Status = table.Column(type: "int", nullable: false),
                    Turn = table.Column(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });
            migration.CreateTable(
                name: "Universe",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universe", x => x.Id);
                });
            migration.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    GameId = table.Column(type: "int", nullable: true),
                    Name = table.Column(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Game_GameId",
                        columns: x => x.GameId,
                        referencedTable: "Game",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "StarSystem",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    HasSafeBerth = table.Column(type: "bit", nullable: false),
                    HasShipyard = table.Column(type: "bit", nullable: false),
                    LawLevel = table.Column(type: "int", nullable: false),
                    Name = table.Column(type: "nvarchar(max)", nullable: true),
                    PatrolRating = table.Column(type: "int", nullable: false),
                    SecurityRating = table.Column(type: "int", nullable: false),
                    SpacePortClass = table.Column(type: "int", nullable: false),
                    UniverseId = table.Column(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarSystem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StarSystem_Universe_UniverseId",
                        columns: x => x.UniverseId,
                        referencedTable: "Universe",
                        referencedColumn: "Id");
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropSequence("DefaultSequence");
            migration.DropTable("Game");
            migration.DropTable("Player");
            migration.DropTable("StarSystem");
            migration.DropTable("Universe");
        }
    }
}
