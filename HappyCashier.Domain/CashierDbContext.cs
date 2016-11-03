using System.Data.Entity;

using HappyCashier.Domain.Entities;

namespace HappyCashier.Domain
{
	public class CashierDbContext : DbContext
	{
		public CashierDbContext()
			: base("name=CashierConnectionString")
		{
			Database.SetInitializer<CashierDbContext>(new DropCreateDatabaseAlways<CashierDbContext>());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Account>().HasKey<int>(k => k.Id);
			modelBuilder.Entity<Account>().Property(p => p.Name).IsRequired();
			modelBuilder.Entity<Account>().Property(p => p.Password).IsRequired();
			modelBuilder.Entity<Account>().Property(p => p.LastActivity).IsOptional();
		}

		public DbSet<Account> Account { get; set; }
		public DbSet<Good> Good { get; set; }
		public DbSet<Sale> Sale { get; set; }
		public DbSet<SaleItem> SaleItem { get; set; }
	}
}
