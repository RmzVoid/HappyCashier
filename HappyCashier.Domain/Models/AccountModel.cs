using System;
using System.Collections.Generic;

using HappyCashier.Domain.DataSources;

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

		public void Create(string account, string password)
		{
			_dataSource.Create(account, password);
		}

		public void Delete(string account)
		{
			_dataSource.Delete(account);
		}

		public bool Login(string account, string password)
		{
			return _dataSource.IsValidAccount(account, password);
		}

		private IAccountDataSource _dataSource;
	}
}
