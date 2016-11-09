using System;
using System.Collections.Generic;

using NSubstitute;
using NUnit.Framework;

using HappyCashier.Domain.Models;
using HappyCashier.Presenter.Common;
using HappyCashier.Presenter.Views;
using HappyCashier.Presenter.Presenters;
using HappyCashier.Presenter.DataTransferObjects;

using GoodsModel = HappyCashier.Domain.DataTransferObjects.Goods;
using GoodsObject = HappyCashier.Presenter.DataTransferObjects.Goods;
using PositionObject = HappyCashier.Presenter.DataTransferObjects.Position;
using DocumentModel = HappyCashier.Domain.DataTransferObjects.Document;
using DocumentObject = HappyCashier.Presenter.DataTransferObjects.Document;


namespace HappyCashier.Test
{
	[TestFixture]
	public class SalePresenterTests
	{
		[SetUp]
		public void SetUp()
		{
			_view = Substitute.For<ISaleView>();
			_model = Substitute.For<ISaleModel>();
			_controller = Substitute.For<IApplicationController>();

			_model.OpenSale(Arg.Any<int>())
				.Returns(x => x.Arg<int>() == 1 ? 3 : -1);

			_model.GetGoods(Arg.Any<string>())
				.ReturnsForAnyArgs(x => x.Arg<string>() == "Макароны" ? null : new GoodsModel() { Id = 1, Name = x.Arg<string>(), Price = 100 });

			var presenter = new SalePresenter(_controller, _view, _model);
			presenter.Run(new Account() { Id = 1, Name = "Витя" });
		}

		[Test]
		public void SalePresenter_OpenSale()
		{
			_view.Account.Returns(new Account() { Id = 1, Name = "Витя" });
			_view.OpenSaleRequested += Raise.Event<Action>();
			Assert.AreEqual(_view.Document.Id, 3);
			CollectionAssert.IsEmpty(_view.Document.Positions);
			Assert.AreEqual(_view.Document.Total, 0);
			Assert.IsNull(_view.Document.CloseTime);
			Assert.IsNotNull(_view.Document.OpenTime);
		}

		[Test]
		public void SalePresenter_CloseSale()
		{
			ICollection<PositionObject> positions = new List<PositionObject>()
			{
				new PositionObject() { Id = 1, Name = "Яйцо 1 сорт 10 шт", Price = 33.80m, Quantity = 3},
				new PositionObject() { Id = 2, Name = "Яйцо 2 сорт 10 шт", Price = 30.20m, Quantity = 3},
				new PositionObject() { Id = 3, Name = "Яйцо 3 сорт 10 шт", Price = 27.65m, Quantity = 3}
			};

			_view.Document.Returns<DocumentObject>(new DocumentObject(1)
			{
				OpenTime = DateTime.MinValue,
				CloseTime = DateTime.MaxValue,
				Positions = positions
			});

			_view.CloseSaleRequested += Raise.Event<Action>();

			Assert.IsNull(_view.Document);
		}

		[Test]
		public void SalePresenter_CloseSale_DocumentIsNull()
		{
			DocumentObject document = null;

			_view.Document.Returns<DocumentObject>(document);

			_view.CloseSaleRequested += Raise.Event<Action>();

			_model.DidNotReceive().CloseSale(Arg.Any<DocumentModel>());
		}

		[Test]
		public void SalePresenter_CloseSale_DocumentNoPositions()
		{
			ICollection<PositionObject> positions = new List<PositionObject>();

			_view.Document.Returns<DocumentObject>(new DocumentObject(1)
			{
				OpenTime = DateTime.MinValue,
				CloseTime = DateTime.MaxValue,
				Positions = positions
			});

			_view.CloseSaleRequested += Raise.Event<Action>();

			_model.DidNotReceive().CloseSale(Arg.Any<DocumentModel>());
		}

		[Test]
		public void SalePresenter_CloseSale_DocumentPositionsIsNull()
		{
			_view.Document.Returns<DocumentObject>(new DocumentObject(1)
			{
				OpenTime = DateTime.MinValue,
				CloseTime = DateTime.MaxValue,
				Positions = null
			});

			_view.CloseSaleRequested += Raise.Event<Action>();

			_model.DidNotReceive().CloseSale(Arg.Any<DocumentModel>());
		}

		[Test]
		public void SalePresenter_GoodInfoRequest_Success()
		{
			_view.GoodsNameRequested.Returns<string>("Тушёнка Великая Китайская Стена");

			_view.GoodsInfoRequested += Raise.Event<Action>();

			_view.Received().GoodsInfoReturned(Arg.Is<GoodsObject>(g => g.Id == 1 && g.Name == "Тушёнка Великая Китайская Стена" && g.Price == 100));
			_view.DidNotReceive().ShowError(Arg.Any<string>());
		}

		[Test]
		public void SalePresenter_GoodInfoRequest_RequestedNameIsNull()
		{
			string goodsName = null;
			_view.GoodsNameRequested.Returns<string>(goodsName);

			_view.GoodsInfoRequested += Raise.Event<Action>();

			_view.DidNotReceive().GoodsInfoReturned(Arg.Any<GoodsObject>());
			_view.DidNotReceive().ShowError(Arg.Any<string>());
		}

		[Test]
		public void SalePresenter_GoodInfoRequest_RequestedNameIsEmpty()
		{
			_view.GoodsNameRequested.Returns<string>(string.Empty);

			_view.GoodsInfoRequested += Raise.Event<Action>();

			_view.DidNotReceive().GoodsInfoReturned(Arg.Any<GoodsObject>());
			_view.DidNotReceive().ShowError(Arg.Any<string>());
		}

		[Test]
		public void SalePresenter_GoodInfoRequest_RequestedNameIsWhitespace()
		{
			_view.GoodsNameRequested.Returns<string>("   ");

			_view.GoodsInfoRequested += Raise.Event<Action>();

			_view.DidNotReceive().GoodsInfoReturned(Arg.Any<GoodsObject>());
			_view.DidNotReceive().ShowError(Arg.Any<string>());
		}

		[Test]
		public void SalePresenter_GoodInfoRequest_GoodsNotFound()
		{
			_view.GoodsNameRequested.Returns<string>("Макароны");

			_view.GoodsInfoRequested += Raise.Event<Action>();

			_view.DidNotReceive().GoodsInfoReturned(Arg.Any<GoodsObject>());
			_view.Received().ShowError(Arg.Any<string>());
		}

		private ISaleView _view;
		private ISaleModel _model;
		private IApplicationController _controller;
	}
}
