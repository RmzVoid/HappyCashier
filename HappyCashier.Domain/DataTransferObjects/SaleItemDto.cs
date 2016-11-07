using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyCashier.Domain.DataTransferObjects
{
	public class SaleItemDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public decimal Amount { get; set; }
		public decimal Total { get { return Price * Amount; } }
	}
}
