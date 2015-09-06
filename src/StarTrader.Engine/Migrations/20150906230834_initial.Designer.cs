using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using StarTrader.Engine;
using Microsoft.Data.Entity.SqlServer.Metadata;

namespace StarTrader.Engine.Migrations
{
    [DbContext(typeof(StarTraderContext))]
    partial class initial
    {
        public override string Id
        {
            get { return "20150906230834_initial"; }
        }

        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta7-15540")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn);

            modelBuilder.Entity("StarTrader.Engine.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("Created");

                    b.Property<string>("Name");

                    b.Property<int>("OwnerId");

                    b.Property<int>("Status");

                    b.Property<int>("Turn");

                    b.Property<int?>("UniverseId");

                    b.Key("Id");
                });

            modelBuilder.Entity("StarTrader.Engine.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn);

                    b.Property<int?>("GameId");

                    b.Property<string>("Name");

                    b.Property<int>("OwnerId");

                    b.Key("Id");
                });

            modelBuilder.Entity("StarTrader.Engine.StarSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn);

                    b.Property<bool>("HasSafeBerth");

                    b.Property<bool>("HasShipyard");

                    b.Property<int>("LawLevel");

                    b.Property<string>("Name");

                    b.Property<int>("PatrolRating");

                    b.Property<int>("SecurityRating");

                    b.Property<int>("SpacePortClass");

                    b.Property<int?>("UniverseId");

                    b.Key("Id");
                });

            modelBuilder.Entity("StarTrader.Engine.Universe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn);

                    b.Key("Id");
                });

            modelBuilder.Entity("StarTrader.Engine.Game", b =>
                {
                    b.Reference("StarTrader.Engine.Universe")
                        .InverseCollection()
                        .ForeignKey("UniverseId");
                });

            modelBuilder.Entity("StarTrader.Engine.Player", b =>
                {
                    b.Reference("StarTrader.Engine.Game")
                        .InverseCollection()
                        .ForeignKey("GameId");
                });

            modelBuilder.Entity("StarTrader.Engine.StarSystem", b =>
                {
                    b.Reference("StarTrader.Engine.Universe")
                        .InverseCollection()
                        .ForeignKey("UniverseId");
                });
        }
    }
}
