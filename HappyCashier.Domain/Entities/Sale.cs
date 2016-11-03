using System;
using System.Collections.Generic;

namespace HappyCashier.Domain.Entities
{
	public class Sale : BaseEntity
	{
		public DateTime? @DateTime { get; set; }
		public int AccountId { get; set; }
		public ICollection<SaleItem> SaleItems { get; set; }
	}
}
