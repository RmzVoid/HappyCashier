using System.Collections.Generic;

namespace HappyCashier.Domain.DataSources
{
	public interface IAccountDataSource
	{
		IEnumerable<string> GetAccountList();
		string GetRecentActive();
		void Create(string account, string password);
		void Delete(string account);
		bool IsValidAccount(string account, string password);
	}
}
