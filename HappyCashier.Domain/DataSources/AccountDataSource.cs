﻿using System.Collections.Generic;
using System.Linq;

using HappyCashier.Domain.DatabaseLayer;
using HappyCashier.Domain.Entities;

namespace HappyCashier.Domain.DataSources
{
	public class DatabaseAccountDataSource : IAccountDataSource
	{
		public DatabaseAccountDataSource(DatabaseContext context)
		{
			_context = context;
		}

		public string GetRecentActive()
		{
			return _context.Account
				.OrderByDescending(a => a.LastActivity)
				.Select(a => a.Name)
				.FirstOrDefault();
		}

		public IEnumerable<string> GetAccountList()
		{
			return _context.Account
				.Select(a => a.Name)
				.ToList();
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

		public bool IsValidAccount(string account, string password)
		{
			// usually account name case insensitive, but now won't use CI comparing
			return _context.Account.Where(a => a.Name == account && a.Password == password).FirstOrDefault() != null;
		}

		private DatabaseContext _context;
	}
}
