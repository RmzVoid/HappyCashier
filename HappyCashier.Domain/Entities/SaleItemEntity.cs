using System;

namespace HappyCashier.Domain.Entities
{
	public class SaleItemEntity : BaseEntity
	{
		public int SaleId { get; set; }
		public int GoodId { get; set; }
		public float Price { get; set; }
		public float Amount { get; set; }
	}
}
