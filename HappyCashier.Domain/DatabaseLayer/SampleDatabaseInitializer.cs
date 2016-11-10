using System.Collections.Generic;
using System.Data.Entity;

using HappyCashier.Domain.Entities;

namespace HappyCashier.Domain.DatabaseLayer
{
	class SampleDatabaseInitializer<T> : DropCreateDatabaseAlways<T>
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

			List<Goods> goods = new List<Goods>
			{
				new Goods(){ Name = "Чеснок", Quantity = 15.807m, Price = 19.80m },
				new Goods(){ Name = "Арбуз", Quantity = 25.910m, Price = 29.90m },
				new Goods(){ Name = "Картофель", Quantity = 45.342m, Price = 13.70m },
				new Goods(){ Name = "Мясо", Quantity = 12.677m, Price = 289.10m },
				new Goods(){ Name = "Печенье", Quantity = 3.233m, Price = 43.60m },
				new Goods(){ Name = "Водка", Quantity = 20m, Price = 405.20m },
				new Goods(){ Name = "Лимонад", Quantity = 40m, Price = 28.40m },
				new Goods(){ Name = "Сигареты", Quantity = 34m, Price = 90.90m },
				new Goods(){ Name = "Сыр", Quantity = 13m, Price = 388.45m },
			};

			context.Account.AddRange(accounts);
			context.Goods.AddRange(goods);
			context.SaveChanges();
		}
	}
}
