using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using StarTrader.Engine;

namespace StarTrader.Engine.Migrations
{
    [ContextType(typeof(StarTraderContext))]
    partial class ading_universe
    {
        public override string Id
        {
            get { return "20150716045620_ading_universe"; }
        }
        
        public override string ProductVersion
        {
            get { return "7.0.0-beta5-13549"; }
        }
        
        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("SqlServer:DefaultSequenceName", "DefaultSequence")
                .Annotation("SqlServer:Sequence:.DefaultSequence", "'DefaultSequence', '', '1', '10', '', '', 'Int64', 'False'")
                .Annotation("SqlServer:ValueGeneration", "Sequence");
            
            builder.Entity("StarTrader.Engine.Game", b =>
                {
                    b.Property<int>("Id")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity)
                        .Annotation("SqlServer:ValueGeneration", "Identity");
                    
                    b.Property<DateTimeOffset>("Created");
                    
                    b.Property<string>("Name");
                    
                    b.Property<int>("OwnerId");
                    
                    b.Property<int>("Status");
                    
                    b.Property<int>("Turn");
                    
                    b.Property<int?>("UniverseId");
                    
                    b.Key("Id");
                });
            
            builder.Entity("StarTrader.Engine.Player", b =>
                {
                    b.Property<int>("Id")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity)
                        .Annotation("SqlServer:ValueGeneration", "Identity");
                    
                    b.Property<int?>("GameId");
                    
                    b.Property<string>("Name");
                    
                    b.Property<int>("OwnerId");
                    
                    b.Key("Id");
                });
            
            builder.Entity("StarTrader.Engine.StarSystem", b =>
                {
                    b.Property<int>("Id")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity)
                        .Annotation("SqlServer:ValueGeneration", "Identity");
                    
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
            
            builder.Entity("StarTrader.Engine.Universe", b =>
                {
                    b.Property<int>("Id")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity)
                        .Annotation("SqlServer:ValueGeneration", "Identity");
                    
                    b.Key("Id");
                });
            
            builder.Entity("StarTrader.Engine.Game", b =>
                {
                    b.Reference("StarTrader.Engine.Universe")
                        .InverseCollection()
                        .ForeignKey("UniverseId");
                });
            
            builder.Entity("StarTrader.Engine.Player", b =>
                {
                    b.Reference("StarTrader.Engine.Game")
                        .InverseCollection()
                        .ForeignKey("GameId");
                });
            
            builder.Entity("StarTrader.Engine.StarSystem", b =>
                {
                    b.Reference("StarTrader.Engine.Universe")
                        .InverseCollection()
                        .ForeignKey("UniverseId");
                });
        }
    }
}
