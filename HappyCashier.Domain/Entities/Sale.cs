using System;
using System.Collections.Generic;

namespace HappyCashier.Domain.Entities
{
	public class Sale : EntityBase
	{
		public DateTime? @DateTime { get; set; }
		public Account Account { get; set; }
		public ICollection<SaleItem> SaleItems { get; set; }
	}
}
