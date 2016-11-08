using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyCashier.Presenter.DataTransferObjects
{
	public class Document
	{
		public int Id { get; set; }
		public DateTime OpenTime {get; set;}
		public DateTime CloseTime { get; set; }
		public List<Position> Positions { get; set; }
		public decimal Total { get { return Positions.Sum(p => p.Total); } }

		public Document(int id)
		{
			Id = id;
			OpenTime = DateTime.Now;
			CloseTime = DateTime.MaxValue;
			Positions = new List<Position>();
		}
	}
}
