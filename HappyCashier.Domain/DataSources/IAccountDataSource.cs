using System.Collections.Generic;

using HappyCashier.Domain.Entities;

namespace HappyCashier.Domain.DataSources
{
	public interface IAccountDataSource
	{
		ISet<string> GetAccountList();
		string GetRecentActive();
		Account GetAccount(string account, string password);
		void UpdateAccountInfo(Account account);
	}
}
