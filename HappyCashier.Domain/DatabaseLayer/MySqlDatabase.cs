using System.Collections.Generic;

using HappyCashier.Domain.Entities;

namespace HappyCashier.Domain.DatabaseLayer
{
	public class MySqlDatabase : IDatabase
	{
		public MySqlDatabase()
		{
			this.context = new CashierDbContext(); // remove cretion of cashierdbcontext inside ctor
		}

		public IEnumerable<Account> GetAccountsList()
		{
			return new List<Account>() { context.Account.Find(1) };
		}

		private CashierDbContext context;
	}
}
