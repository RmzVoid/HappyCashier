using System;
using System.Collections.Generic;

namespace HappyCashier.Domain.DataTransferObjects
{
	public class Document
	{
		public int Id { get; set; }
		public DateTime? DateTimeOpen { get; set; }
		public DateTime? DateTimeClose { get; set; }
		public IEnumerable<Position> Positions { get; set; }
	}
}
