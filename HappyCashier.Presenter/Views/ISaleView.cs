using System;

using HappyCashier.Domain.DataTransferObjects;

namespace HappyCashier.Presenter.Views
{
	public interface ISaleView : IView
	{
		Account Account { get; set; }
		int SaleId { get; set; }
		string GoodNameRequested { get; }
		void GoodInfoReturned(GoodDto good);

		void ShowError(string message);

		event Action OpenSaleRequested;
		event Action CloseSaleRequested;
		event Action GoodInfoRequested;
	}
}
