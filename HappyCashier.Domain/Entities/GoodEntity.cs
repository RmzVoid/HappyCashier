using System;

namespace HappyCashier.Domain.Entities
{
	public class GoodEntity : BaseEntity
	{
		public string Name { get; set; }
		public float Price { get; set; }
		public float Amount { get; set; }
	}
}
