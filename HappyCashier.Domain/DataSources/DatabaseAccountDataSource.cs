using System.Collections.Generic;
using System.Linq;

using HappyCashier.Domain.DatabaseLayer;
using HappyCashier.Domain.Entities;

namespace HappyCashier.Domain.DataSources
{
	// Implementation using database as source
	public class DatabaseAccountDataSource : IAccountDataSource
	{
		public DatabaseAccountDataSource(DatabaseContext context)
		{
			_context = context;
		}

		#region IAccountDataSource implementation

		public string GetRecentActive()
		{
			return _context.Account
				.OrderByDescending(a => a.LastActivity)
				.Select(a => a.Name)
				.FirstOrDefault();
		}

		public ISet<string> GetAccountList()
		{
			return new HashSet<string>(_context.Account
				.Select(a => a.Name)
				.ToList());
		}

		public void Create(string account, string password)
		{
			_context.Account.Add(new Account() { Name = account, Password = password });
			_context.SaveChanges();
		}

		public void Delete(string account)
		{
			_context.Account.Remove(new Account { Name = account });
			_context.SaveChanges();
		}

		public Account GetAccount(string account, string password)
		{
			// usually account name case insensitive, but now won't use CI comparing
			return _context.Account.Where(a => a.Name == account && a.Password == password).FirstOrDefault();
		}

		public void UpdateAccountInfo(Account account)
		{
			var accountToUpdate = _context.Entry<Account>(account);

			if (accountToUpdate != null)
			{
				accountToUpdate.Entity.Name = account.Name;
				accountToUpdate.Entity.Password = account.Password;
				accountToUpdate.Entity.LastActivity = account.LastActivity;
			}

			_context.SaveChanges();
		}

		#endregion

		#region Private fields

		private DatabaseContext _context;

		#endregion
	}
}
