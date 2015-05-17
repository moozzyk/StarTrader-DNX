using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using StarTrader.Engine;

namespace StarTrader.Engine.Migrations
{
    [ContextType(typeof(StarTraderContext))]
    partial class StarTraderContextModelSnapshot : ModelSnapshot
    {
        public override IModel Model
        {
            get
            {
                var builder = new BasicModelBuilder()
                    .Annotation("SqlServer:ValueGeneration", "Sequence");

                builder.Entity("StarTrader.Engine.Model.Game", b =>
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
                        b.Key("Id");
                    });

                builder.Entity("StarTrader.Engine.Model.Player", b =>
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

                builder.Entity("StarTrader.Engine.Model.Player", b =>
                    {
                        b.ForeignKey("StarTrader.Engine.Model.Game", "GameId");
                    });

                return builder.Model;
            }
        }
    }
}
