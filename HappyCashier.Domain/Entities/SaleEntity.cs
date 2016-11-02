using System;
using System.Collections.Generic;

namespace HappyCashier.Domain.Entities
{
	public class SaleEntity : BaseEntity
	{
		public DateTime @DateTime { get; set; }
		public int AccountId { get; set; }
		public ICollection<SaleItemEntity> SaleItems { get; set; }
	}
}
