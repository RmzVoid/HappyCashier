using System;

using HappyCashier.Presenter.Common;
using HappyCashier.Presenter.DataTransferObjects;

namespace HappyCashier.Presenter.Views
{
	public interface ISaleView : IView
	{
		Account Account { get; set; }
		Document Document { get; set; }
		string GoodsNameRequested { get; }

		void GoodsInfoReturned(Goods good);
		void ShowError(string message);

		event Action OpenSaleRequested;
		event Action CloseSaleRequested;
		event Action GoodsInfoRequested;
	}
}
