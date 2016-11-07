using System;
using System.Collections.Generic;
using System.Linq;

using HappyCashier.Domain.DataTransferObjects;
using HappyCashier.Domain.Models;
using HappyCashier.Presenter.Views;

namespace HappyCashier.Presenter.Presenters
{
	public class SalePresenter : IPresenter
	{
		public SalePresenter(ISaleView view, ISaleModel model)
		{
			_view = view;
			_model = model;

			_view.GoodInfoRequested += goodInfoRequested;
			_view.CloseSaleRequested += closeSaleRequested;
			_view.OpenSaleRequested += openSaleRequested;
		}

		public void Run()
		{
			_view.ShowMe();
		}

		private void openSaleRequested()
		{
			Document document = new Document(_model.OpenSale(_view.Account.Id));

		}

		private void closeSaleRequested()
		{
			_model.CloseSale(new SaleDto() { Id = _view.SaleId });
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

		private ISaleView _view;
		private ISaleModel _model;
	}
}
