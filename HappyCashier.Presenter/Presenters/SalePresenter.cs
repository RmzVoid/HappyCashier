using System.Linq;

using HappyCashier.Domain.DataTransferObjects;
using HappyCashier.Domain.Models;
using HappyCashier.Presenter.Common;
using HappyCashier.Presenter.DataTransferObjects;
using HappyCashier.Presenter.Views;

using DocumentModel = HappyCashier.Domain.DataTransferObjects.Document;
using DocumentObject = HappyCashier.Presenter.DataTransferObjects.Document;
using GoodsModel = HappyCashier.Domain.DataTransferObjects.Goods;
using GoodsObject = HappyCashier.Presenter.DataTransferObjects.Goods;
using PositionModel = HappyCashier.Domain.DataTransferObjects.Position;
using PositionObject = HappyCashier.Presenter.DataTransferObjects.Position;

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
			_view.Document = new DocumentObject(_model.OpenSale(_view.Account.Id));
		}

		private void closeSaleRequested()
		{
			DocumentModel saleToClose = new DocumentModel();

			saleToClose.Id = _view.Document.Id;
			saleToClose.DateTimeOpen = _view.Document.OpenTime;
			saleToClose.DateTimeClose = _view.Document.CloseTime;
			saleToClose.Positions = _view.Document.Positions
				.Select<PositionObject, PositionModel>(p => new PositionModel() 
				{ 
					Id = p.Id, 
					Price = p.Price,
					Quantity = p.Quantity
				});

			_model.CloseSale(saleToClose);
		}

		private void goodInfoRequested()
		{
			GoodsModel goodsModel = _model.GetGood(_view.GoodNameRequested);

			if (goodsModel != null)
			{
				GoodsObject goods = new GoodsObject()
					{
						Id = goodsModel.Id,
						Name = goodsModel.Name,
						Price = goodsModel.Price
					};

				_view.GoodInfoReturned(goods);
			}
			else
				_view.ShowError("Товар '" + _view.GoodNameRequested + "' не найден");
		}

		private ISaleModel _model;
	}
}
