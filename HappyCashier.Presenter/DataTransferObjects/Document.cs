using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyCashier.Presenter.DataTransferObjects
{
	public class Document
	{
		public class Goods
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public decimal Quantity { get; set; }
			public decimal Price { get; set; }
			public decimal Total { get { return Math.Round(Quantity * Price, 2); } }
		}

		public int Id { get; set; }
		public DateTime OpenTime {get; set;}
		public DateTime CloseTime { get; set; }
		public List<Goods> Positions { get; set; }
		public decimal Total { get { return Positions.Sum(p => p.Total); } }

		public Document(int id)
		{
			Id = id;
			OpenTime = DateTime.Now;
			CloseTime = DateTime.MaxValue;
			Positions = new List<Goods>();
		}
	}
}
