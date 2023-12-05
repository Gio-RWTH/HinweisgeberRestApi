using Microsoft.EntityFrameworkCore;

namespace HinweigeberRestApi.Data
{
    public class HinweisDbContext : DbContext
    {
		public HinweisDbContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}

		public DbSet<Meldung> Meldungs => Set<Meldung>();
        public DbSet<Massnahme> Massnahmes => Set<Massnahme>();
    }
}
