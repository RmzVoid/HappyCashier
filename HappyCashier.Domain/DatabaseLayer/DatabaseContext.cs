using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

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
			modelBuilder.Entity<Entities.Account>()
				.HasKey<int>(k => k.Id);
			modelBuilder.Entity<Entities.Account>()
				.Property(p => p.Name)
				.IsRequired()
				.HasMaxLength(64);
			modelBuilder.Entity<Entities.Account>()
				.Property(p => p.Password)
				.IsRequired()
				.HasMaxLength(16);
			modelBuilder.Entity<Entities.Account>()
				.Property(p => p.LastActivity)
				.IsOptional();

			modelBuilder.Entity<Entities.Good>()
				.HasKey<int>(k => k.Id);
			modelBuilder.Entity<Entities.Good>()
				.Property(p => p.Name)
				.IsRequired()
				.HasMaxLength(64);
			modelBuilder.Entity<Entities.Good>()
				.Property(p => p.Price)
				.IsRequired().HasPrecision(8, 2);
			modelBuilder.Entity<Entities.Good>()
				.Property(p => p.Amount)
				.IsRequired().HasPrecision(8, 3);

			modelBuilder.Entity<Entities.Sale>()
				.HasKey<int>(k => k.Id);
			modelBuilder.Entity<Entities.Sale>()
				.Property(p => p.DateTime)
				.IsRequired();

			modelBuilder.Entity<Entities.SaleItem>()
				.HasKey<int>(k => k.Id);
			modelBuilder.Entity<Entities.SaleItem>()
				.Property(p => p.Price)
				.IsRequired()
				.HasPrecision(8, 2);
			modelBuilder.Entity<Entities.SaleItem>()
				.Property(p => p.Amount)
				.IsRequired()
				.HasPrecision(8, 3);
		}

		public DbSet<Account> Account { get; set; }
		public DbSet<Good> Good { get; set; }
		public DbSet<Sale> Sale { get; set; }
		public DbSet<SaleItem> SaleItem { get; set; }
	}
}
