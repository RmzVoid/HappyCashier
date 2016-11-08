using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
