using System;
using System.Linq;

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

		public int OpenSale(int accountId)
		{
			return _dataSource.OpenSale(accountId);
		}

		public void CloseSale(SaleDto saleToClose)
		{
			_dataSource.CloseSale(saleToClose);
		}

		public GoodDto GetGood(string name)
		{
			return _dataSource.GetGood(name);
		}

		private ISaleDataSource _dataSource;
	}
}
