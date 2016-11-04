using System;

namespace HappyCashier.Domain.Entities
{
	public class Good : EntityBase
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public decimal Amount { get; set; }
	}
}
