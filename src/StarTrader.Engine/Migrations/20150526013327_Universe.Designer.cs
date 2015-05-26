using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using StarTrader.Engine;

namespace StarTrader.Engine.Migrations
{
    [ContextType(typeof(StarTraderContext))]
    partial class Universe
    {
        public override string Id
        {
            get { return "20150526013327_Universe"; }
        }
        
        public override string ProductVersion
        {
            get { return "7.0.0-beta4-12943"; }
        }
        
        public override IModel Target
        {
            get
            {
                var builder = new BasicModelBuilder()
                    .Annotation("SqlServer:ValueGeneration", "Sequence");
                
                builder.Entity("StarTrader.Engine.Game", b =>
                    {
                        b.Property<DateTimeOffset>("Created")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 1)
                            .Annotation("SqlServer:ValueGeneration", "Identity");
                        b.Property<string>("Name")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<int>("OwnerId")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<int>("Status")
                            .Annotation("OriginalValueIndex", 4);
                        b.Property<int>("Turn")
                            .Annotation("OriginalValueIndex", 5);
                        b.Key("Id");
                    });
                
                builder.Entity("StarTrader.Engine.Player", b =>
                    {
                        b.Property<int?>("GameId")
                            .Annotation("OriginalValueIndex", 0)
                            .Annotation("ShadowIndex", 0);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 1)
                            .Annotation("SqlServer:ValueGeneration", "Identity");
                        b.Property<string>("Name")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<int>("OwnerId")
                            .Annotation("OriginalValueIndex", 3);
                        b.Key("Id");
                    });
                
                builder.Entity("StarTrader.Engine.StarSystem", b =>
                    {
                        b.Property<bool>("HasSafeBerth")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<bool>("HasShipyard")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 2)
                            .Annotation("SqlServer:ValueGeneration", "Identity");
                        b.Property<int>("LawLevel")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<string>("Name")
                            .Annotation("OriginalValueIndex", 4);
                        b.Property<int>("PatrolRating")
                            .Annotation("OriginalValueIndex", 5);
                        b.Property<int>("SecurityRating")
                            .Annotation("OriginalValueIndex", 6);
                        b.Property<int>("SpacePortClass")
                            .Annotation("OriginalValueIndex", 7);
                        b.Property<int?>("UniverseId")
                            .Annotation("OriginalValueIndex", 8)
                            .Annotation("ShadowIndex", 0);
                        b.Key("Id");
                    });
                
                builder.Entity("StarTrader.Engine.Universe", b =>
                    {
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 0)
                            .Annotation("SqlServer:ValueGeneration", "Identity");
                        b.Key("Id");
                    });
                
                builder.Entity("StarTrader.Engine.Player", b =>
                    {
                        b.ForeignKey("StarTrader.Engine.Game", "GameId");
                    });
                
                builder.Entity("StarTrader.Engine.StarSystem", b =>
                    {
                        b.ForeignKey("StarTrader.Engine.Universe", "UniverseId");
                    });
                
                return builder.Model;
            }
        }
    }
}
