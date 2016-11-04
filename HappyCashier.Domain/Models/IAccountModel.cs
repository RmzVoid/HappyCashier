using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyCashier.Domain.Models
{
	public interface IAccountModel
	{
		string GetRecentActive();
		IEnumerable<string> GetAccountList();
		void Create(string account, string password);
		void Delete(string id);
		bool Login(string account, string password);
	}
}
