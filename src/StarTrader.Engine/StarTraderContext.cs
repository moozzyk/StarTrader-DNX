using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using StarTrader.Engine.Model;

namespace StarTrader.Engine
{
	public class StarTraderContext : DbContext
	{
		public StarTraderContext(DbContextOptions options)
			: base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Game>(entity =>
			{
				entity.Key(e => e.Id);
				entity.Property(e=>e.Id)
					.ForSqlServer().UseIdentity();
			});
		}

		public DbSet<Game> Games { get; set; }
	}
}