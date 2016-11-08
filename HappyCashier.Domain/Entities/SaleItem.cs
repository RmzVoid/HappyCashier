using System;

namespace HappyCashier.Domain.Entities
{
	public class SaleItem : EntityBase
	{
		public Sale Sale { get; set; }
		public Good Good { get; set; }
		public decimal Price { get; set; }
		public decimal Quantity { get; set; }
	}
}
