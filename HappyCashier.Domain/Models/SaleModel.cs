using System;

using HappyCashier.Domain.DataSources;
using HappyCashier.Domain.DataTransferObjects;

namespace HappyCashier.Domain.Models
{
	public class SaleModel : ISaleModel
	{
		public SaleModel(ISaleDataSource dataSource)
		{
			if (dataSource == null)
				throw new NullReferenceException("dataSource is null");

			_dataSource = dataSource;
		}

		#region ISaleModel implementation

		public int OpenSale(int accountId)
		{
			return _dataSource.OpenSale(accountId);
		}

		public void CloseSale(Document saleToClose)
		{
			_dataSource.CloseSale(saleToClose);
		}

		public Goods GetGoods(string name)
		{
			return _dataSource.GetGood(name);
		}

		#endregion

		#region Private fields

		private ISaleDataSource _dataSource;

		#endregion
	}
}
