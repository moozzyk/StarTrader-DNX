using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace StarTrader.Engine.Migrations
{
    public partial class ading_universe : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.AddColumn(
                name: "UniverseId",
                table: "Game",
                type: "int",
                nullable: true);
            migration.AddForeignKey(
                name: "FK_Game_Universe_UniverseId",
                table: "Game",
                column: "UniverseId",
                referencedTable: "Universe",
                referencedColumn: "Id");
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropForeignKey(name: "FK_Game_Universe_UniverseId", table: "Game");
            migration.DropColumn(name: "UniverseId", table: "Game");
        }
    }
}
