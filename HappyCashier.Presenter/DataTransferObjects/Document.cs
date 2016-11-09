using System;
using System.Collections.Generic;
using System.Linq;

namespace HappyCashier.Presenter.DataTransferObjects
{
	public class Document
	{
		public int Id { get; set; }
		public DateTime? OpenTime {get; set;}
		public DateTime? CloseTime { get; set; }
		public ICollection<Position> Positions { get; set; }
		public decimal Total { get { return Positions.Sum(p => p.Total); } }

		public Document(int id)
		{
			Id = id;
			OpenTime = DateTime.Now;
			Positions = new List<Position>();
		}
	}
}
