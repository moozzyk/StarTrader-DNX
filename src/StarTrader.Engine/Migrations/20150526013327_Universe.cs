using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace StarTrader.Engine.Migrations
{
    public partial class Universe : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
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
                name: "StarSystem",
                columns: table => new
                {
                    HasSafeBerth = table.Column(type: "bit", nullable: false),
                    HasShipyard = table.Column(type: "bit", nullable: false),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
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
            migration.AddColumn(
                name: "Turn",
                table: "Game",
                type: "int",
                nullable: false);
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropColumn(name: "Turn", table: "Game");
            migration.DropTable("StarSystem");
            migration.DropTable("Universe");
        }
    }
}
