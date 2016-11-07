using System.Collections.Generic;
using System.Data.Entity;

using HappyCashier.Domain.Entities;

namespace HappyCashier.Domain.DatabaseLayer
{
	class DatabaseInitializer<T> : CreateDatabaseIfNotExists<T>
		where T : DatabaseContext
	{
		protected override void Seed(T context)
		{
			List<Account> accounts = new List<Account>
			{
				new Account() { Name = "Даша", Password = "11111" },
				new Account() { Name = "Ира", Password = "11111" },
				new Account() { Name = "Петя", Password = "11111" },
			};

			List<Good> goods = new List<Good>
			{
				new Good(){ Name = "Чеснок", Amount = 15.807m, Price = 19.80m },
				new Good(){ Name = "Арбуз", Amount = 25.910m, Price = 29.90m },
				new Good(){ Name = "Картофель", Amount = 45.342m, Price = 13.70m },
				new Good(){ Name = "Мясо", Amount = 12.677m, Price = 289.10m },
				new Good(){ Name = "Печенье", Amount = 3.233m, Price = 43.60m },
				new Good(){ Name = "Водка", Amount = 20m, Price = 405.20m },
				new Good(){ Name = "Лимонад", Amount = 40m, Price = 28.40m },
				new Good(){ Name = "Сигареты", Amount = 34m, Price = 90.90m },
				new Good(){ Name = "Сыр", Amount = 13m, Price = 388.45m },
			};

			context.Account.AddRange(accounts);
			context.Good.AddRange(goods);
			context.SaveChanges();

			base.Seed(context);
		}
	}
}
