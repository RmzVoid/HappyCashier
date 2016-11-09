namespace HappyCashier.Domain.Entities
{
	public class SaleItem : EntityBase
	{
		public Goods Goods { get; set; }
		public decimal Price { get; set; }
		public decimal Quantity { get; set; }
	}
}
