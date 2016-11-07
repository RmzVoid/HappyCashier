using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyCashier.Presenter.DataTransferObjects
{
	public class SaleInfo
	{
		public int Id {get; set;}
		public IEnumerable<SaleItem> Items { get; private set; }
		public decimal Total { get { return Items.Sum(item => item.Total); } }
	}
}
