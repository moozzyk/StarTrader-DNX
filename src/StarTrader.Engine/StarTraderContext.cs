using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using StarTrader.Engine.Model;

namespace StarTrader.Engine
{
	public class StarTraderContext : DbContext
	{
		// TODO: Remove - used for migrations only but should not be needed
		public StarTraderContext()
		{}

		public StarTraderContext(DbContextOptions options)
			: base(options)
		{ }

		// TODO: Remove - used for migrations only but should not be needed
		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			if(!builder.IsConfigured)
			{
				builder.UseSqlServer(@"Server=(localdb)\v11.0;Database=StarTrader;integrated security=True;");
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Game>(entity =>
			{
				entity.Key(e => e.Id);
				entity.Property(e=>e.Id)
					.ForSqlServer().UseIdentity();
			});
			
			builder.Entity<Player>(entity => 
			{
				entity.Key(e => e.Id);
				entity.Property(e => e.Id)
					.ForSqlServer().UseIdentity();
			});
		}

		public DbSet<Game> Games { get; set; }
	}
}