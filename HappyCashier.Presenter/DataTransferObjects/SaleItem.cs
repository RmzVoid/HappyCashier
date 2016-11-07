using HappyCashier.Domain.DataTransferObjects;

namespace HappyCashier.Presenter.DataTransferObjects
{
	public class SaleItem
	{
		public GoodDto Good { get; set; }
		public decimal Price { get; set; }
		public decimal Amount { get; set; }
		public decimal Total { get { return Price * Amount; } }
	}
}
