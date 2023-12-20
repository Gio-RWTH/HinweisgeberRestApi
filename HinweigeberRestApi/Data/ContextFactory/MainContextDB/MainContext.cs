using Microsoft.EntityFrameworkCore;

namespace HinweigeberRestApi.Data.ContextFactory.MainContextDB
{
    public class MainContext : DbContext
    {
		public MainContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}
		public DbSet<Partner> Partners => Set<Partner>();
		public DbSet<Filiale> Filiales => Set<Filiale>();

	}
}
