using HappyCashier.Domain.DataTransferObjects;

namespace HappyCashier.Domain.Models
{
	public interface ISaleModel
	{
		int OpenSale(int accountId);
		void CloseSale(Document saleToClose);
		Goods GetGoods(string name);
	}
}
