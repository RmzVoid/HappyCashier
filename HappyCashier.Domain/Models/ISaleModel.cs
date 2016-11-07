﻿using HappyCashier.Domain.DataTransferObjects;

namespace HappyCashier.Domain.Models
{
	public interface ISaleModel
	{
		int OpenSale(int accountId);
		void CloseSale(SaleDto saleToClose);
		GoodDto GetGood(string name);
	}
}
