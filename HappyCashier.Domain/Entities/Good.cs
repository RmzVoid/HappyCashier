namespace HappyCashier.Domain.Entities
{
	public class Goods : EntityBase
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public decimal Quantity { get; set; }
	}
}
