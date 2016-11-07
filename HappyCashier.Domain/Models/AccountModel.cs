using System;
using System.Collections.Generic;

using HappyCashier.Domain.DataSources;
using HappyCashier.Domain.Entities;

namespace HappyCashier.Domain.Models
{
	public class AccountModel : IAccountModel
	{
		public AccountModel(IAccountDataSource dataSource)
		{
			if (dataSource == null)
				throw new NullReferenceException("dataSource is null");

			_dataSource = dataSource;
		}

		public string GetRecentActive()
		{
			return _dataSource.GetRecentActive();
		}

		public IEnumerable<string> GetAccountList()
		{
			return _dataSource.GetAccountList();
		}

		public Account GetAccount(string account, string password)
		{
			return _dataSource.GetAccount(account, password);
		}

		private IAccountDataSource _dataSource;
	}
}
