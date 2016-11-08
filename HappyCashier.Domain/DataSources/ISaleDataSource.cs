using HappyCashier.Domain.DataTransferObjects;

namespace HappyCashier.Domain.DataSources
{
	public interface ISaleDataSource
	{
		int OpenSale(int accountId);
		void CloseSale(Document saleToClose);
		Goods GetGood(string name);
	}
}
