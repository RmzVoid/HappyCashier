using System;

using HappyCashier.Presenter.Common;
using HappyCashier.Presenter.DataTransferObjects;

namespace HappyCashier.Presenter.Views
{
	public interface ISaleView : IView
	{
		Account Account { get; set; }
		Document Document { get; set; }
		string GoodNameRequested { get; }

		void GoodInfoReturned(Goods good);

		void ShowError(string message);

		event Action OpenSaleRequested;
		event Action CloseSaleRequested;
		event Action GoodInfoRequested;
	}
}
