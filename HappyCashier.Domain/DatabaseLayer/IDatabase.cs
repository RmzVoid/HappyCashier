using System.Collections.Generic;

using HappyCashier.Domain.Entities;

namespace HappyCashier.Domain.DatabaseLayer
{
	public interface IDatabase
	{
		IEnumerable<Account> GetAccountsList();
	}
}
