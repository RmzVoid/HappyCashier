using System;
using System.Collections.Generic;

namespace HappyCashier.Domain.Entities
{
	public class Sale : EntityBase
	{
		public DateTime? DateTimeOpen { get; set; }
		public DateTime? DateTimeClose { get; set; }
		public Account Account { get; set; }
		public ICollection<SaleItem> SaleItems { get; set; }
	}
}
