using System.Collections.Generic;

using HappyCashier.Domain.Entities;

namespace HappyCashier.Domain.Models
{
	public interface IAccountModel
	{
		string GetRecentActive();
		ISet<string> GetAccountList();
		Account GetAccount(string account, string password);
		void UpdateAccountInfo(Account account);
	}
}
