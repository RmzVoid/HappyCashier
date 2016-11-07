using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyCashier.Domain.DataTransferObjects
{
	public class SaleDto
	{
		public int Id {get; set;}
		public IEnumerable<SaleItemDto> Items { get; private set; }
		public decimal Total { get { return Items.Sum(item => item.Total); } }
	}
}
