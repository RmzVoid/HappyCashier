using System.Data.Entity;

using HappyCashier.Domain.Entities;

namespace HappyCashier.Domain.DatabaseLayer
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext()
			: base("name=CashierConnectionString")
		{
			Database.SetInitializer<DatabaseContext>(new DropCreateDatabaseIfModelChanges<DatabaseContext>());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Account>()
				.HasKey<int>(k => k.Id);
			modelBuilder.Entity<Account>()
				.Property(p => p.Name)
				.IsRequired()
				.HasMaxLength(64);
			modelBuilder.Entity<Account>()
				.Property(p => p.Password)
				.IsRequired()
				.HasMaxLength(16);
			modelBuilder.Entity<Account>()
				.Property(p => p.LastActivity)
				.IsOptional();

			modelBuilder.Entity<Goods>()
				.HasKey<int>(k => k.Id);
			modelBuilder.Entity<Goods>()
				.Property(p => p.Name)
				.IsRequired()
				.HasMaxLength(64);
			modelBuilder.Entity<Goods>()
				.Property(p => p.Price)
				.IsRequired().HasPrecision(8, 2);
			modelBuilder.Entity<Goods>()
				.Property(p => p.Quantity)
				.IsRequired().HasPrecision(8, 3);

			modelBuilder.Entity<Sale>()
				.HasKey<int>(k => k.Id);
			modelBuilder.Entity<Sale>()
				.Property(p => p.DateTimeOpen)
				.IsOptional();
			modelBuilder.Entity<Sale>()
				.Property(p => p.DateTimeClose)
				.IsOptional();

			modelBuilder.Entity<SaleItem>()
				.HasKey<int>(k => k.Id);
			modelBuilder.Entity<SaleItem>()
				.Property(p => p.Price)
				.IsRequired()
				.HasPrecision(8, 2);
			modelBuilder.Entity<SaleItem>()
				.Property(p => p.Quantity)
				.IsRequired()
				.HasPrecision(8, 3);
		}

		public DbSet<Account> Account { get; set; }
		public DbSet<Goods> Goods { get; set; }
		public DbSet<Sale> Sale { get; set; }
		public DbSet<SaleItem> SaleItem { get; set; }
	}
}
