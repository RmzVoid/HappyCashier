using System;

namespace HappyCashier.Domain.Entities
{
	public class AccountEntity : BaseEntity
	{
		public string Name { get; set; }
		public string Password { get; set; }
		public DateTime LastActivity { get; set; }
	}
}
