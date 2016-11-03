using System;

namespace HappyCashier.Domain.Entities
{
	public class Good : BaseEntity
	{
		public string Name { get; set; }
		public float Price { get; set; }
		public float Amount { get; set; }
	}
}
