using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyCashier.Domain.Entities
{
	public class Account : EntityBase
	{
		public string Name { get; set; }
		public string Password { get; set; }
		public DateTime? LastActivity { get; set; }
	}
}
