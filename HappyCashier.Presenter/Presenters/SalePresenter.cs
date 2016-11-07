using HappyCashier.Domain.DataTransferObjects;
using HappyCashier.Domain.Models;
using HappyCashier.Presenter.Common;
using HappyCashier.Presenter.DataTransferObjects;
using HappyCashier.Presenter.Views;

namespace HappyCashier.Presenter.Presenters
{
	public class SalePresenter : BasePresenter<ISaleView, Account>
	{
		public SalePresenter(IApplicationController controller, ISaleView view, ISaleModel model)
			: base(controller, view)
		{
			_model = model;

			_view.GoodInfoRequested += goodInfoRequested;
			_view.CloseSaleRequested += closeSaleRequested;
			_view.OpenSaleRequested += openSaleRequested;
		}

		public override void Run(Account account)
		{
			_view.Account = account;
			_view.ShowMe();
		}

		private void openSaleRequested()
		{
			_view.Document = new Document(_model.OpenSale(_view.Account.Id));
		}

		private void closeSaleRequested()
		{
		}

		private void goodInfoRequested()
		{
			GoodDto good = _model.GetGood(_view.GoodNameRequested);

			if (good != null)
			{
				_view.GoodInfoReturned(good);
			}
			else
				_view.ShowError("Товар '" + _view.GoodNameRequested + "' не найден");
		}

		private ISaleModel _model;
	}
}
