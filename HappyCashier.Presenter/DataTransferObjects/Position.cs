using System;

namespace HappyCashier.Presenter.DataTransferObjects
{
	public class Position
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Quantity { get; set; }
		public decimal Price { get; set; }
		public decimal Total { get { return Math.Round(Quantity * Price, 2); } }
	}
}
